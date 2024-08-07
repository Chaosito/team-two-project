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

        public string Name { get; set; } = string.Empty;

        public string Login { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
    }
}
