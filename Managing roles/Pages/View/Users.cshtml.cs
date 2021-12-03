using Managing_roles.Data;
using Managing_roles.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace Managing_roles.Pages.View
{
    public class UsersModel : PageModel
    {
        private readonly DataManager _service;

        public UsersModel(DataManager service)
        {
            this._service = service;
        }
        public List<User> Users { get; set; }
        public List<Role> AllRoles { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchBar { get; set; }

        [BindProperty(SupportsGet = true)]
        public int FilterRoleId { get; set; }
        public void OnGet()
        {
            // Список всех фильтров для вывода фильтров на странице
            AllRoles = _service.Role.GetRoles();

            Users = _service.User.GetUsers();

            //Поиск
            Users = Users.UserSearch(SearchBar);

            //Фильтр
            Users = Users.FilterUsersByRoles(FilterRoleId, AllRoles);
        }
    }
}
