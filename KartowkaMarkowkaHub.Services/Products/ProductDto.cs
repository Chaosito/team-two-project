using AutoMapper;
using KartowkaMarkowkaHub.Core.Domain;

namespace KartowkaMarkowkaHub.Services.Products
{
    /// <summary>
    /// Данные о товаре, для сервиса
    /// </summary>
    public class ProductDto
    {
        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }
    }

    public class ProductDtoProfile: Profile
    {
        public ProductDtoProfile()
        {
            CreateMap<ProductDto, Product>();
        }
    }
}