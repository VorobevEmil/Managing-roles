using Managing_roles.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Managing_roles.Data.Repositories
{
    public class RoleUserService
    {
        private readonly AppDbContext _context;

        public RoleUserService(AppDbContext context)
        {
            this._context = context;
        }

        public List<RoleUser> GetRoleUserById(string id)
        {
            return _context.RoleUsers
                .Include(t => t.Role)
                .Include(t => t.User)
                .Where(t => t.UserId == id)
                .ToList();
        }

        public async Task CreateRoleUser(RoleUser roleUser)
        {
            _context.RoleUsers.Add(roleUser);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRoleUser(RoleUser roleUser)
        {
            var role = await _context.RoleUsers
                 .Where(t => t.UserId == roleUser.UserId && t.RoleId == roleUser.RoleId)
                 .FirstOrDefaultAsync();

            _context.RoleUsers.Remove(role);

            await _context.SaveChangesAsync();
        }
    }
}
