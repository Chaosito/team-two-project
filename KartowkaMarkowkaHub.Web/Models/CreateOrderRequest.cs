using AutoMapper;
using KartowkaMarkowkaHub.Core.Domain;

namespace KartowkaMarkowkaHub.Web.Models
{
    public class CreateOrderRequest
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

    public class OrderCreateRequestProfile : Profile
    {
        public OrderCreateRequestProfile()
        {
            CreateMap<CreateOrderRequest, Order>()
                .ForMember(d => d.ProductId, o => o.MapFrom(r => r.ProductId));
        }
    }
}
