namespace KartowkaMarkowkaHub.Web.Models
{
    public class RoleUserRequest
    {
        public Guid UserId { get; set; }

        public Guid RoleId { get; set; }
    }

    public class UserRequest
    {
        public Guid? Id { get; set; }

        public string Login { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public IEnumerable<RoleRequest> Roles { get; set; }
    }

    public class RoleRequest
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
