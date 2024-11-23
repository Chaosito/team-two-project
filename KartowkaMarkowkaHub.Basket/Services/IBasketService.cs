namespace KartowkaMarkowkaHub.Basket.Services
{
    public interface IBasketService
    {
        /// <summary>
        /// Получает все товары для клиента
        /// </summary>
        /// <returns></returns>
        Task<BasketViewModel> Get(Guid userId);

        /// <summary>
        /// Добавляет продукт в корзину
        /// </summary>
        /// <param name="productId">id продукта</param>
        Task Create(Guid productId, Guid userId);

        /// <summary>
        /// Удаляет продукт из корзины
        /// </summary>
        /// <param name="productId">id продукта</param>
        Task Remove(Guid productId, Guid userId);

    }
}
