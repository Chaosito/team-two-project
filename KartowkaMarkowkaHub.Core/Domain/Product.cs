using System.ComponentModel.DataAnnotations;

namespace KartowkaMarkowkaHub.Core.Domain.Product
{
    /// <summary>
    /// Продукт
    /// </summary>
    internal class Product: BaseEntity
    {
        /// <summary>
        /// Наименование
        /// </summary>
        [MaxLength(300)]
        internal string Name { get; set; } = "";

        /// <summary>
        /// Цена
        /// </summary>
        internal decimal Price { get; set; }
    }
}