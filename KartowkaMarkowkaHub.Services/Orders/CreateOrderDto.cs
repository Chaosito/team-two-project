namespace KartowkaMarkowkaHub.Services.Orders
{
    public class CreateOrderDto
    {
        /// <summary>
        /// Номер заказа
        /// </summary>
        public uint Number { get; set; }

        /// <summary>
        /// id продукта
        /// </summary>
        public Guid ProductId { get; set; }
    }
}
