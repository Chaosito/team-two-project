using KartowkaMarkowkaHub.Services.Orders;
using MediatR;

namespace KartowkaMarkowkaHub.Application.Orders.Queries.GetAllOrders
{
    internal class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, OrdersViewModel>
    {
        private readonly IOrderService _orderService;

        public GetAllOrdersQueryHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public Task<OrdersViewModel> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = _orderService.Get();
            var orderViewModels = orders
                .Select(x => new OrderViewModel()
                {
                    Id = x.Id,
                    Number = x.Number,
                    Product = x.Product,
                    OrderStatusName = x.OrderStatusName,
                }).ToList();

            return Task.FromResult(new OrdersViewModel { Orders = orderViewModels });
        }
    }
}
