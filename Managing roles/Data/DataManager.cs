using Managing_roles.Data.Repositories;

namespace Managing_roles.Data
{
    public class DataManager
    {
        public UserService User { get; set; }
        public RoleService Role { get; set; }
        public RoleUserService RoleUser { get; set; }
        public DataManager(UserService user, RoleService role, RoleUserService roleUser)
        {
            User = user;
            Role = role;
            RoleUser = roleUser;
        }
    }
}
