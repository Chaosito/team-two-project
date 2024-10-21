namespace KartowkaMarkowkaHub.Services.Products
{
    public interface IProductService
    {
        /// <summary>
        /// Получает товары фермера
        /// </summary>
        /// <param name="farmerId">id фермера</param>
        /// <returns></returns>
        Task<IEnumerable<GetProductDto>> Get(Guid farmerId);

        /// <summary>
        /// Получает все товары
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<GetProductDto>> Get();

        /// <summary>
        /// Создаёт товар
        /// </summary>
        /// <param name="productDto">модель товара</param>
        void Create(CreateProductDto productDto, Guid userId);

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
        void Update(Guid productId, UpdateProductDto productDto);
    }
}
