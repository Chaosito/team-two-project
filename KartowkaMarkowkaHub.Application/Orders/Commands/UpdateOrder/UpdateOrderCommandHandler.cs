using KartowkaMarkowkaHub.Services.Orders;
using MediatR;

namespace KartowkaMarkowkaHub.Application.Orders.Commands.UpdateOrder
{
    internal class UpdateOrderCommandHandler
        : IRequestHandler<UpdateOrderCommand, bool>
    {
        private readonly IOrderService _orderService;

        public UpdateOrderCommandHandler(IOrderService roleService)
        {
            _orderService = roleService;
        }

        public Task<bool> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            _orderService.Update(
                request.Id,
                new UpdateOrderDto
                {
                    OrderStatusId = request.OrderStatusId,
                    ProductId = request.ProductId,
                });

            return Task.FromResult(true);
        }
    }
}
