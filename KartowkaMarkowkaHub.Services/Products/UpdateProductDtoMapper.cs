using AutoMapper;
using KartowkaMarkowkaHub.Core.Domain;

namespace KartowkaMarkowkaHub.Services.Products
{
    internal class UpdateProductDtoMapper : Profile
    {
        public UpdateProductDtoMapper()
        {
            CreateMap<UpdateProductDto, Product>()
                .ForMember(d => d.Name, o => o.MapFrom(r => r.Name))
                .ForMember(d => d.Price, o => o.MapFrom(r => r.Price));
        }
    }
}