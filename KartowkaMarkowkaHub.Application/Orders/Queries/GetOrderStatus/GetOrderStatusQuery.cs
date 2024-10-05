using MediatR;

namespace KartowkaMarkowkaHub.Application.Orders.Queries.GetOrderStatus
{
    public class GetOrderStatusQuery : IRequest<string>
    {
        public Guid OrderId { get; set; }
    }
}
