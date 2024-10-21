namespace KartowkaMarkowkaHub.Application.Products.Queries.GetAllProducts
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }
    }
}
