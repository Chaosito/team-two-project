using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartowkaMarkowkaHub.Core.Domain
{
    public class Order:BaseEntity
    {
        public DateTime CreationDate { get; set; }

        public DateTime? CompletionDate { get; set; }

        public Guid OrderStatusId { get; set; }
        public OrderStatus OrderStatus { get; set; }


        /// <summary>
        /// Арбитраж ? (спор по сделке)
        /// </summary>
        public bool IsArbitrated { get; set; }

        /// <summary>
        /// Комбинированный заказ ?
        /// </summary>
        public bool IsComboOrder { get; set; }

        // Внешние ключи и навигационные свойства
        public Guid ClientId { get; set; }
        public Client Client { get; set; }

        public Guid FarmerId { get; set; }
        public Farmer Farmer { get; set; }

        // Навигационное свойство
        public ICollection<OrderItem> OrderItems { get; set; }

        /// <summary>
        /// Рейтинг по завершению заказа
        /// </summary>
        public int? Rating { get; set; }
    }
}
