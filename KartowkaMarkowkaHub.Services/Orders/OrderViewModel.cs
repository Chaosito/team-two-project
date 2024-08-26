﻿using AutoMapper;
using KartowkaMarkowkaHub.Core.Domain;
using KartowkaMarkowkaHub.Services.Products;

namespace KartowkaMarkowkaHub.Services.Orders
{
    /// <summary>
    /// Данные о заказе продуктов, для представления
    /// </summary>
    public class OrderViewModel
    {
        public Guid Id { get; set; }

        public uint Number { get; set; }

        public required ProductViewModel Product { get; set; }

        public string OrderStatusName { get; set; } = string.Empty;
    }

    public class OrderViewModelProfile : Profile
    {
        public OrderViewModelProfile()
        {
            CreateMap<Order, OrderViewModel>()
                .ForPath(d => d.Product, o => o.MapFrom(p => new ProductViewModel
                {
                    Id = p.Product.Id,
                    Name = p.Product.Name,
                    Price = p.Product.Price,
                }))
                .ForMember(d => d.OrderStatusName, o => o.MapFrom(p => p.OrderStatus.Name));
        }
    }
}