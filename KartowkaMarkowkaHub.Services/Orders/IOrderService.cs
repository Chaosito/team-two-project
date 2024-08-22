namespace KartowkaMarkowkaHub.Services.Orders
{
    public interface IOrderService
    {
        /// <summary>
        /// Получает заказы клиента
        /// </summary>
        /// <param name="clientId">id клиента</param>
        /// <returns></returns>
        IEnumerable<OrderViewModel> Get(Guid clientId);

        /// <summary>
        /// Получает все заказы
        /// </summary>
        /// <returns></returns>
        IEnumerable<OrderViewModel> Get();

        /// <summary>
        /// Создаёт заказ
        /// </summary>
        /// <param name="orderId">модель заказа</param>
        void Create(OrderCreateRequest orderCreateRequest, Guid userId);

        /// <summary>
        /// Обновляет заказ
        /// </summary>
        /// <param name="orderId">id заказа</param>
        /// <param name="orderUpdateRequest">модель заказа</param>
        void Update(Guid orderId, OrderUpdateRequest orderUpdateRequest);

        /// <summary>
        /// Удаляет заказ
        /// </summary>
        /// <param name="orderId">id заказа</param>
        void Remove(Guid orderId);
    }
}