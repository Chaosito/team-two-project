using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartowkaMarkowkaHub.Core
{
    public class User: BaseEntity
    {
        public string Login { get; set; }

        /// <summary>
        /// Пароль для входа
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Контактный E-mail
        /// </summary>
        public string Email { get; set; }

        public bool IsDeleted { get; set; }
    }
}
