using Managing_roles.Data;
using System.Collections.Generic;
using System.Linq;

namespace Managing_roles.Extensions
{
    public static class SearchExtension
    {
        //Поиск по пользователям
        public static List<User> UserSearch(this IEnumerable<User> users, string searchBar)
        {
            return users.Where(t => t.Name.ToLower().Contains(searchBar == null ? "" : searchBar.ToLower())).ToList();
        }

        //Поиск по ролям
        public static List<Role> RoleSearch(this IEnumerable<Role> roles, string searchBar)
        {
            return roles.Where(t => t.Name.ToLower().Contains(searchBar == null ? "" : searchBar.ToLower())).ToList();
        }
    }
}
