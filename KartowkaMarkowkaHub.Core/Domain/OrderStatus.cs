using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartowkaMarkowkaHub.Core.Domain
{
    /// <summary>
    /// Статус заказа
    /// </summary>
    public class OrderStatus: BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public StatusType StatusType { get; set; }

        /// <summary>
        /// Заказы
        /// </summary>
        public virtual ICollection<Order> Orders { get; set; } = [];
    }

    public enum StatusType
    {
        Created = 1,

        InProcess = 2,

        Completed = 3
    }
}
