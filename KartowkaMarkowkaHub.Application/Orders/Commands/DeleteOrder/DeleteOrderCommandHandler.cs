using KartowkaMarkowkaHub.Services.Orders;
using MediatR;

namespace KartowkaMarkowkaHub.Application.Orders.Commands.RemoveOrder
{
    internal class DeleteOrderCommandHandler
        : IRequestHandler<DeleteOrderCommand, bool>
    {
        private readonly IOrderService _orderService;

        public DeleteOrderCommandHandler(IOrderService roleService)
        {
            _orderService = roleService;
        }

        public Task<bool> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            _orderService.Remove(request.Id);

            return Task.FromResult(true);
        }
    }
}
