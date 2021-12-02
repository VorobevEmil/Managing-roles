using Managing_roles.Data;
using Managing_roles.Data.Entities;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Managing_roles
{
    public class UserRolesMiddleware
    {
        private readonly RequestDelegate _next;

        public UserRolesMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, DataManager service)
        {

            if (httpContext.User != null && httpContext.User.Identity.IsAuthenticated)
            {
                List<Role> roles = service.Role.GetRoles()
                    .Where(t => t.RoleUsers.Select(t => t.UserId).Contains(httpContext.User.FindFirst(ClaimTypes.PrimarySid).Value))
                    .ToList();
                List<Claim> claims = new List<Claim>();
                if (roles.Count == 0)
                {
                    await service.User.CreateUser(new User()
                    {
                        Id = httpContext.User.FindFirst(ClaimTypes.PrimarySid).Value,
                        Name = httpContext.User.Identity.Name
                    });

                    await service.RoleUser.CreateRoleUser(new RoleUser()
                    {
                        RoleId = 1,
                        UserId = httpContext.User.FindFirst(ClaimTypes.PrimarySid).Value
                    });

                    claims.Add(new Claim(ClaimsIdentity.DefaultRoleClaimType, "User"));
                }
                else
                {
                    foreach (var role in roles)
                    {
                        claims.Add(new Claim(ClaimsIdentity.DefaultRoleClaimType, role.Name));
                    }
                }

                var appIdentity = new ClaimsIdentity(claims);
                httpContext.User.AddIdentity(appIdentity);
            }

            await _next(httpContext);
        }
    }
}
