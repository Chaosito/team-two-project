using KartowkaMarkowkaHub.Services.Roles;

namespace KartowkaMarkowkaHub.Services.Account
{
    public class GetUserDTO
    {
        public Guid? Id { get; set; }

        public string Login { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public IEnumerable<GetRoleDTO> Roles { get; set; }
    }
}
