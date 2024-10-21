using MediatR;

namespace KartowkaMarkowkaHub.Application.Orders.Commands.UpdateOrderStatus
{
    public partial class UpdateOrderStatusCommand : IRequest<bool>
    {
        public Guid OrderId { get; set; }
    }
}
