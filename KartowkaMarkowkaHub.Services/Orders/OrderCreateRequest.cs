﻿using AutoMapper;
using KartowkaMarkowkaHub.Core.Domain;

namespace KartowkaMarkowkaHub.Services.Orders
{
    public class OrderCreateRequest
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
            CreateMap<OrderCreateRequest, Order>()
                .ForMember(d => d.ProductId, o => o.MapFrom(r => r.ProductId));
        }
    }
}
