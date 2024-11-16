using AutoMapper;
using KartowkaMarkowkaHub.Core.Domain;

namespace KartowkaMarkowkaHub.Services.Products
{
    /// <summary>
    /// Данные о товаре, для представления
    /// </summary>
    public class GetProductDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }
    }

    public class ProductViewModelProfile: Profile
    {
        public ProductViewModelProfile()
        {
            CreateMap<Product, GetProductDto>();
        }
    }
}