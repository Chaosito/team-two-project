using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartowkaMarkowkaHub.Core.Domain
{
    public class Client: User
    {
        /// <summary>
        /// ФИО клиента
        /// </summary>
        public string Name { get; set; }

        public string Address { get; set; }

        // Навигационное свойство
        public ICollection<Order> Orders { get; set; }
    }
}
