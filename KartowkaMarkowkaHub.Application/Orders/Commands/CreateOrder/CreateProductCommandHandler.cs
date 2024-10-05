using KartowkaMarkowkaHub.Services.Orders;
using MediatR;

namespace KartowkaMarkowkaHub.Application.Orders.Commands.CreateOrder
{
    internal class CreateOrderCommandHandler
        : IRequestHandler<CreateOrderCommand, Guid>
    {
        private readonly IOrderService _orderService;

        public CreateOrderCommandHandler(IOrderService roleService)
        {
            _orderService = roleService;
        }

        public Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            _orderService.Create(
                new CreateOrderDto
                {
                    Number = request.Number,
                    ProductId = request.ProductId,
                },
                request.UserId);

            return Task.FromResult(Guid.Empty);
        }
    }
}
