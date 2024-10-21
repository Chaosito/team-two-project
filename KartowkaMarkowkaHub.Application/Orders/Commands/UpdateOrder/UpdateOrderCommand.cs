using MediatR;

namespace KartowkaMarkowkaHub.Application.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public Guid OrderStatusId { get; set; }

        public Guid ProductId { get; set; }
    }
}
