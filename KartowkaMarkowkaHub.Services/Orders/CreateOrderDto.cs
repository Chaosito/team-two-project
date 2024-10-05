using AutoMapper;
using KartowkaMarkowkaHub.Core.Domain;

namespace KartowkaMarkowkaHub.Services.Orders
{
    public class CreateOrderDto
    {
        /// <summary>
        /// Номер заказа
        /// </summary>
        public uint Number { get; set; }

        /// <summary>
        /// id продукта
        /// </summary>
        public Guid ProductId { get; set; }
    }

    public class OrderCreateDtoProfile : Profile
    {
        public OrderCreateDtoProfile()
        {
            CreateMap<CreateOrderDto, Order>()
                .ForMember(d => d.ProductId, o => o.MapFrom(r => r.ProductId));
        }
    }
}
