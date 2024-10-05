using MediatR;

namespace KartowkaMarkowkaHub.Application.Orders.Commands.RemoveOrder
{
    public class DeleteOrderCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
