using AutoMapper;
using KartowkaMarkowkaHub.Core.Domain;

namespace KartowkaMarkowkaHub.Services.Orders
{
    internal class CreateOrderDtoMapper : Profile
    {
        public CreateOrderDtoMapper()
        {
            CreateMap<CreateOrderDto, Order>()
                .ForMember(d => d.ProductId, o => o.MapFrom(r => r.ProductId))
                .ForMember(d => d.Number, o => o.MapFrom(r => r.Number));
        }
    }
}
