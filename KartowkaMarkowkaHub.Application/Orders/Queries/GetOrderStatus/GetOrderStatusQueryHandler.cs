using KartowkaMarkowkaHub.Services.Orders;
using MediatR;

namespace KartowkaMarkowkaHub.Application.Orders.Queries.GetOrderStatus
{
    internal class GetOrderStatusQueryHandler : IRequestHandler<GetOrderStatusQuery, string>
    {
        private readonly IOrderService _orderService;

        public GetOrderStatusQueryHandler(IOrderService roleService)
        {
            _orderService = roleService;
        }

        public Task<string> Handle(GetOrderStatusQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_orderService.GetStatusName(request.OrderId));
        }
    }
}
