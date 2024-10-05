using MediatR;

namespace KartowkaMarkowkaHub.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }

        public uint Number { get; set; }

        public Guid ProductId { get; set; }
    }
}
