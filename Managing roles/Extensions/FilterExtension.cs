using Managing_roles.Data;
using System.Collections.Generic;
using System.Linq;

namespace Managing_roles.Extensions
{
    public static class FilterExtension
    {
        public static List<User> FilterUsersByRoles(this IEnumerable<User> users, int roleId)
        {
            switch (roleId)
            {
                case 1:
                case 2:
                case 3:
                    return users.Where(t => t.RoleUsers.Select(t => t.RoleId).Contains(roleId)).ToList();
                default:
                    return users.ToList();
            }
        }
    }
}
