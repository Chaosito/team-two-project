﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartowkaMarkowkaHub.Core.Domain
{
    /// <summary>
    /// Заказ продуктов
    /// </summary>
    public class Order:BaseEntity
    {
        /// <summary>
        /// Номер заказа, для клиента
        /// </summary>
        public uint Number { get; set; }
        
        /// <summary>
        /// id статуса заказа 
        /// </summary>
        public Guid OrderStatusId { get; set; }
        public virtual required OrderStatus OrderStatus { get; set; }

        /// <summary>
        /// id клиента
        /// </summary>
        public Guid ClientId { get; set; }

        public virtual required User Client {  get; set; }

        /// <summary>
        /// id заказанного продукта
        /// (связь 1 к 1 для возможности отмены заказа, без потери других продуктов)
        /// </summary>
        public Guid ProductId { get; set; }

        public virtual required Product Product { get; set; }

        //public DateTime CreationDate { get; set; }

        //public DateTime? CompletionDate { get; set; }

        /// <summary>
        /// Арбитраж ? (спор по сделке)
        /// </summary>
        //public bool IsArbitrated { get; set; }

        /// <summary>
        /// Комбинированный заказ ?
        /// </summary>
        //public bool IsComboOrder { get; set; }

        // Внешние ключи и навигационные свойства
        //public Guid ClientId { get; set; }
        //public Client Client { get; set; }

        //public Guid FarmerId { get; set; }
        //public Farmer Farmer { get; set; }

        // Навигационное свойство
        //public ICollection<OrderItem> OrderItems { get; set; }

        /// <summary>
        /// Рейтинг по завершению заказа
        /// </summary>
        //public int? Rating { get; set; }
    }
}
