using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartowkaMarkowkaHub.Core.Domain
{
    public class Farmer : User
    {
        /// <summary>
        /// Наименование компании
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Адрес
        /// </summary>
        public string Address { get; set; }

        // Навигационное свойство
        public ICollection<Product> Products { get; set; }

        public User? User { get; set; }

        public Guid? UserId { get; set; }
    }
}
