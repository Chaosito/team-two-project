namespace KartowkaMarkowkaHub.Web.Models
{
    public class UpdateProductRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
