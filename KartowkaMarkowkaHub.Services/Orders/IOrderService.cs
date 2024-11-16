namespace KartowkaMarkowkaHub.Services.Orders
{
    public interface IOrderService
    {
        /// <summary>
        /// Получает заказы клиента
        /// </summary>
        /// <param name="clientId">id клиента</param>
        /// <returns></returns>
        IEnumerable<GetOrderDto> Get(Guid clientId);

        /// <summary>
        /// Получает все заказы
        /// </summary>
        /// <returns></returns>
        IEnumerable<GetOrderDto> Get();

        /// <summary>
        /// Создаёт заказ
        /// </summary>
        /// <param name="orderId">модель заказа</param>
        void Create(CreateOrderDto orderCreateRequest, Guid userId);

        /// <summary>
        /// Обновляет заказ
        /// </summary>
        /// <param name="orderId">id заказа</param>
        /// <param name="orderUpdateRequest">модель заказа</param>
        void Update(Guid orderId, UpdateOrderDto orderUpdateRequest);

        /// <summary>
        /// Удаляет заказ
        /// </summary>
        /// <param name="orderId">id заказа</param>
        void Remove(Guid orderId);

        /// <summary>
        /// Получает текущий статус заказа
        /// </summary>
        /// <param name="orderId">id заказа</param>
        /// <returns></returns>
        string GetStatusName(Guid orderId);

        /// <summary>
        /// Устанавливает следующий статус заказа
        /// </summary>
        /// <param name="orderId"></param>
        void SetNextStatus(Guid orderId);
    }
}