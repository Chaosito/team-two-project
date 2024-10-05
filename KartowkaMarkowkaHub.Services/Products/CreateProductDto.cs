using AutoMapper;
using KartowkaMarkowkaHub.Core.Domain;

namespace KartowkaMarkowkaHub.Services.Products
{
    public class CreateProductDto
    {
        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }
    }

    public class ProductDtoProfile: Profile
    {
        public ProductDtoProfile()
        {
            CreateMap<CreateProductDto, Product>();
        }
    }


}