using Managing_roles.Data.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Managing_roles.Data
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        [Required (ErrorMessage = "Поле название роли обязательно для заполнения")]
        [Display(Name = "Название роли")]
        public string Name { get; set; }
        public IEnumerable<RoleUser> RoleUsers { get; set; }
    }
}
