using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartowkaMarkowkaHub.Core.Domain
{
    public class OrderItem : BaseEntity
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }

        // Внешний ключ для заказа
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
    }
}
