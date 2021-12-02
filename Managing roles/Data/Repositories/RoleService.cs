using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Managing_roles.Data.Repositories
{
    public class RoleService
    {
        private readonly AppDbContext _context;

        public RoleService(AppDbContext context)
        {
            this._context = context;
        }

        public List<Role> GetRoles()
        {
            return _context.Roles
                .Include(t => t.RoleUsers)
                .ToList();
        }

        public async Task CreateRole(Role role)
        {
            _context.Roles.Add(role);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRole(int roleId)
        {
            var role = await _context.Roles.FindAsync(roleId);
            if (role is null) { throw new Exception("Unable to find role"); }

            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
        }

    }
}
