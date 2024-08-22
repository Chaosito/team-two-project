using AutoMapper;
using KartowkaMarkowkaHub.Core.Domain;

namespace KartowkaMarkowkaHub.Services.Orders
{
    /// <summary>
    /// Данные о заказе, для сервиса
    /// </summary>
    public class OrderDto
    {
        /// <summary>
        /// Номер заказа
        /// </summary>
        public uint Number {  get; set; }

        /// <summary>
        /// id статуса заказа
        /// </summary>
        public Guid OrderStatusId { get; set; }

        /// <summary>
        /// id продукта
        /// </summary>
        public Guid ProductId { get; set; }
    }

    public class OrderDtoProfile : Profile
    {
        public OrderDtoProfile() 
        {
            CreateMap<OrderDto, Order>()
                .ForMember(d => d.OrderStatusId, o => o.MapFrom(r => r.OrderStatusId))
                .ForMember(d => d.ProductId, o => o.MapFrom(r => r.ProductId));
        }
    }
}
