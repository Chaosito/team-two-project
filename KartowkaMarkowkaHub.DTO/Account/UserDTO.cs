using KartowkaMarkowkaHub.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartowkaMarkowkaHub.DTO.Account
{
    public class UserDTO
    {
        public Guid? Id { get; set; }

        public string Login { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public IEnumerable<RoleDTO> Roles { get; set; }

        public UserDTO(User user)
        {
            Id = user.Id;
            Login = user.Login;
            Email = user.Email;
            Roles = user.Roles.Select(role => new RoleDTO() { Id = role.Role.Id, Name = role.Role.Name, Description = role.Role.Description });
        }

        public UserDTO() { }
    }
}
