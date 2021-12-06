using Managing_roles.Data;
using Managing_roles.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Managing_roles.Pages.Admin
{
    [Authorize("Admin")]
    public class UserModel : PageModel
    {
        private readonly DataManager _service;

        public UserModel(DataManager service)
        {
            this._service = service;
        }

        [BindProperty]
        public List<RoleUser> RoleUsers { get; set; }

        [BindProperty]
        public List<Role> AllRoles { get; set; }

        [BindProperty]
        public List<bool> RolesCheck { get; set; }

        [BindProperty]
        public string UserId { get; set; }


        public void OnGet(string id)
        {
            UserId = id;
            RoleUsers = _service.RoleUser.GetRoleUserById(id);
            AllRoles = _service.Role.GetRoles();

            RolesCheck = new List<bool>();

            for (int i = 0; i < AllRoles.Count; i++)
            {
                RolesCheck.Add(RoleUsers.Select(t => t.RoleId).Contains(AllRoles[i].Id));
            }
        }
        
        public async Task<IActionResult> OnPost()
        {
            List<Role> roles = new List<Role>();

            for (int i = 0; i < AllRoles.Count; i++)
                if (RolesCheck[i])
                    roles.Add(AllRoles[i]);

            List<int> deleteRoles = RoleUsers
                .Where(t => !roles.Select(t => t.Id).Contains(t.RoleId))
                .Select(t => t.RoleId)
                .ToList();

            foreach (var RoleId in deleteRoles)
            {
                var role = RoleUsers.FirstOrDefault(t => t.UserId == UserId && t.RoleId == RoleId);
                RoleUsers.Remove(role);
                await _service.RoleUser.DeleteRoleUser(new RoleUser() { RoleId = RoleId, UserId = UserId });
            }

            List<int> addRoles = roles
                .Where(t => !RoleUsers.Select(t => t.RoleId).Contains(t.Id))
                .Select(t => t.Id)
                .ToList();

            foreach (var RoleId in addRoles)
            {
                await _service.RoleUser.CreateRoleUser(new RoleUser() { RoleId = RoleId, UserId = UserId });
            }

            return RedirectToPage("/Index");
        }
    }
}
