using KartowkaMarkowkaHub.Application.Orders.Queries.GetAllOrders;
using MediatR;

namespace KartowkaMarkowkaHub.Application.Orders.Queries.GetUserOrders
{
    public class GetUserOrdersQuery : IRequest<OrdersViewModel>
    {
        public Guid UserId { get; set; }
    }
}
