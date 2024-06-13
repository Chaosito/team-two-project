using System.ComponentModel.DataAnnotations;

namespace SenpaiMarket.DataAccess.Models
{
    /// <summary>
    /// Продукт
    /// </summary>
    internal class Product: BaseTable
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