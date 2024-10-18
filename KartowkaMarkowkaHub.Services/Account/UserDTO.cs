using KartowkaMarkowkaHub.Core.Domain;
using KartowkaMarkowkaHub.Services.Roles;

namespace KartowkaMarkowkaHub.Services.Account
{
    public class UserDto
    {
        public Guid? Id { get; set; }

        public string Login { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public IEnumerable<GetRoleDTO> Roles { get; set; }

        public UserDto(User user) // todo Mapping?
        {
            Id = user.Id;
            Login = user.Login;
            Email = user.Email;
            Roles = user.Roles.Select(role => new GetRoleDTO() { Id = role.Role.Id, Name = role.Role.Name, Description = role.Role.Description });
        }

        public UserDto() { }
    }
}
