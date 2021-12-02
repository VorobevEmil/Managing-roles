using Managing_roles.Data;
using Managing_roles.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Managing_roles.Pages.Admin
{
    [RoleRequirement("Admin")]
    public class RoleModel : PageModel
    {
        private readonly DataManager _service;
        public RoleModel(DataManager service)
        {
            _service = service;
        }

        [BindProperty]
        public Role Input { get; set; }

        public async Task<IActionResult> OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            await _service.Role.CreateRole(Input);

            return RedirectToPage("/View/Users");
        }
    }
}
