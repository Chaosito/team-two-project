using System.ComponentModel.DataAnnotations;

namespace KartowkaMarkowkaHub.Core.Domain
{
    /// <summary>
    /// Продукт
    /// </summary>
    public class Product : BaseEntity
    {
        /// <summary>
        /// Наименование
        /// </summary>
        [MaxLength(300)]
        public string Name { get; set; } = "";

        /// <summary>
        /// Цена
        /// </summary>
        public decimal Price { get; set; }

        public Guid UserId { get; set; }

        public virtual User User { get; set; }  

        /// <summary>
        /// Оптовая цена
        /// </summary>
        //public decimal OptionalPrice { get; set; }


        //public ProductType ProductType { get; set; }

        /// <summary>
        /// Сертификация
        /// </summary>
        //public string Certification { get; set; } = "";

        // Внешний ключ для фермера
        //public int FarmerId { get; set; }
        //public Farmer Farmer { get; set; }
    }

    //public enum ProductType
    //{
    //    /// <summary>
    //    /// Скоропортящийся
    //    /// </summary>
    //    Perishable = 1,

    //    /// <summary>
    //    /// Не тухнет
    //    /// </summary>
    //    NonPerishable = 2
    //}
}