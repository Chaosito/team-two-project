using KartowkaMarkowkaHub.Services.Products;

namespace KartowkaMarkowkaHub.Services.rabbitmq
{
    public class ProductsResponse
    {
        public IEnumerable<GetProductDto> Products { get; set; } = Enumerable.Empty<GetProductDto>();
    }
}