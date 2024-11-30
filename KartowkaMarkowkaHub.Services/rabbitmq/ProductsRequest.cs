namespace KartowkaMarkowkaHub.Services.rabbitmq
{
    public class ProductsRequest
    {
        public IEnumerable<Guid> ProductIdList { get; set; } = new List<Guid>();
    }
}
