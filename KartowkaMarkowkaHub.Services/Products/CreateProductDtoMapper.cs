using AutoMapper;
using KartowkaMarkowkaHub.Core.Domain;

namespace KartowkaMarkowkaHub.Services.Products
{
    internal class CreateProductDtoMapper : Profile
    {
        public CreateProductDtoMapper()
        {
            CreateMap<CreateProductDto, Product>()
                .ForMember(d => d.Name, o => o.MapFrom(r => r.Name))
                .ForMember(d => d.Price, o => o.MapFrom(r => r.Price));
        }
    }
}