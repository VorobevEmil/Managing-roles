using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Managing_roles.Data.Repositories
{
    public class UserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            this._context = context;
        }

        public List<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public async Task CreateUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }
    }
}
