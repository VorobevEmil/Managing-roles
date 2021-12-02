namespace Managing_roles.Data.Entities
{
    public class RoleUser
    {
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
