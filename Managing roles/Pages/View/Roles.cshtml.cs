using Managing_roles.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
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
        public void OnGet()
        {
            Roles = _service.Role.GetRoles();
        }

        public async Task<IActionResult> OnPost(int roleId)
        {
            await _service.Role.DeleteRole(roleId);

            return Page();
        }
    }
}
