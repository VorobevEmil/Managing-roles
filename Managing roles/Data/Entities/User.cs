using Managing_roles.Data.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Managing_roles.Data
{
    public class User
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<RoleUser> RoleUsers { get; set; }
    }
}
