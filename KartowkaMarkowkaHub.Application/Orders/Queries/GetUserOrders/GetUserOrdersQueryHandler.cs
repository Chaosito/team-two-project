using KartowkaMarkowkaHub.Application.Orders.Queries.GetAllOrders;
using KartowkaMarkowkaHub.Services.Orders;
using MediatR;

namespace KartowkaMarkowkaHub.Application.Orders.Queries.GetUserOrders
{
    internal class GetUserOrdersQueryHandler : IRequestHandler<GetUserOrdersQuery, OrdersViewModel>
    {
        private readonly IOrderService _orderService;

        public GetUserOrdersQueryHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public Task<OrdersViewModel> Handle(GetUserOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = _orderService.Get(request.UserId);
            var orderViewModels = orders
                .Select(x => new GetAllOrders.OrderViewModel()
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
