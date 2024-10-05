using KartowkaMarkowkaHub.Services.Products;

namespace KartowkaMarkowkaHub.Application.Orders.Queries.GetAllOrders
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }

        public uint Number { get; set; }

        public required GetProductDto Product { get; set; }

        public string OrderStatusName { get; set; } = string.Empty;
    }
}
