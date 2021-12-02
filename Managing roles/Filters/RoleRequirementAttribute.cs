using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Managing_roles.Filters
{
    public class RoleRequirementAttribute : TypeFilterAttribute
    {
        public RoleRequirementAttribute(string roleValue) : base(typeof(RoleRequirementFilter))
        {
            Arguments = new object[] { new Claim(ClaimsIdentity.DefaultRoleClaimType, roleValue) };
        }
    }
}
