using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartowkaMarkowkaHub.Services.Products
{
    public interface IProductService
    {
        /// <summary>
        /// Получает товары фермера
        /// </summary>
        /// <param name="farmerId">id фермера</param>
        /// <returns></returns>
        IEnumerable<ProductViewModel> Get(Guid farmerId);

        /// <summary>
        /// Получает все товары
        /// </summary>
        /// <returns></returns>
        IEnumerable<ProductViewModel> Get();

        /// <summary>
        /// Создаёт товар
        /// </summary>
        /// <param name="productDto">модель товара</param>
        void Create(ProductDto productDto, Guid userId);

        /// <summary>
        /// Удаляет товар
        /// </summary>
        /// <param name="productId">id товара</param>
        void Remove(Guid productId);

        /// <summary>
        /// Обновляет модель товара
        /// </summary>
        /// <param name="productId">id товара</param>
        /// <param name="productDto">модель товара</param>
        void Update(Guid productId, ProductDto productDto);
    }

    /// <summary>
    /// Данные о товаре
    /// </summary>
    public class ProductViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }
    }

    public class ProductDto
    {
        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }
    }
}
