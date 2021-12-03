using Managing_roles.Data;
using System.Collections.Generic;
using System.Linq;

namespace Managing_roles.Extensions
{
    public static class FilterExtension
    {
        public static List<User> FilterUsersByRoles(this IEnumerable<User> users, int roleId, List<Role> allRoles)
        {
            if (allRoles.Select(t => t.Id).Contains(roleId))
                return users.Where(t => t.RoleUsers.Select(t => t.RoleId).Contains(roleId)).ToList();

            return users.ToList();
        }
    }
}
