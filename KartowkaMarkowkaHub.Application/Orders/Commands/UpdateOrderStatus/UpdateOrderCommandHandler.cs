using KartowkaMarkowkaHub.Services.Orders;
using MediatR;

namespace KartowkaMarkowkaHub.Application.Orders.Commands.UpdateOrderStatus
{
    internal class UpdateOrderStatusCommandHandler
        : IRequestHandler<UpdateOrderStatusCommand, bool>
    {
        private readonly IOrderService _orderService;

        public UpdateOrderStatusCommandHandler(IOrderService roleService)
        {
            _orderService = roleService;
        }

        public Task<bool> Handle(UpdateOrderStatusCommand request, CancellationToken cancellationToken)
        {
            _orderService.SetNextStatus(request.OrderId);

            return Task.FromResult(true);
        }
    }
}
