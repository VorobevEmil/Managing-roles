using Managing_roles.Data;
using Managing_roles.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Managing_roles.Pages.View
{
    public class RolesModel : PageModel
    {
        private readonly DataManager _service;

        public RolesModel(DataManager service)
        {
            this._service = service;
        }
        public List<Role> Roles { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchBar { get; set; }
        public void OnGet()
        {
            Roles = _service.Role.GetRoles();

            // Поиск по ролям
            Roles = Roles.RoleSearch(SearchBar);
        }

        public async Task<IActionResult> OnPost(int roleId)
        {
            await _service.Role.DeleteRole(roleId);

            return Page();
        }
    }
}
