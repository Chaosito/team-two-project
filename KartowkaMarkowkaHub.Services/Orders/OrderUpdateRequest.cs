using AutoMapper;
using KartowkaMarkowkaHub.Core.Domain;

namespace KartowkaMarkowkaHub.Services.Orders
{
    public class OrderUpdateRequest
    {
        /// <summary>
        /// id статуса заказа
        /// </summary>
        public Guid OrderStatusId { get; set; }

        /// <summary>
        /// id продукта
        /// </summary>
        public Guid ProductId { get; set; }
    }

    public class OrderUpdateRequestProfile : Profile
    {
        public OrderUpdateRequestProfile()
        {
            CreateMap<OrderUpdateRequest, Order>()
                .ForMember(d => d.OrderStatusId, o => o.MapFrom(r => r.OrderStatusId))
                .ForMember(d => d.ProductId, o => o.MapFrom(r => r.ProductId));
        }
    }
}
