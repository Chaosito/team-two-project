namespace KartowkaMarkowkaHub.Basket.Services
{
    public class BasketViewModel
    {
        public Guid Id { get; set; }

        /// <summary>
        /// id продукта
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// наименование продукта
        /// </summary>
        public string ProductName { get; set; } = string.Empty;
    }
}
