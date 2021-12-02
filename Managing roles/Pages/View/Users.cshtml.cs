using Managing_roles.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

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
        public void OnGet()
        {
            Users = _service.User.GetUsers();
        }
    }
}
