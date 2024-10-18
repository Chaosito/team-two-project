namespace KartowkaMarkowkaHub.Services.Orders
{
    public class UpdateOrderDto
    {
        /// <summary>
        /// id статуса заказа
        /// </summary>
        public Guid OrderStatusId { get; set; }

        /// <summary>
        /// id продукта
        /// </summary>
        public Guid ProductId { get; set; }
    }
}
