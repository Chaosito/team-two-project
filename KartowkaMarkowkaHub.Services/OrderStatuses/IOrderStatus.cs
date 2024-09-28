using KartowkaMarkowkaHub.Core.Domain;

namespace KartowkaMarkowkaHub.Services.OrderStatuses
{
    public interface IOrderStatus
    {
        StatusType StatusType { get; }
        StatusType NextStatus(IOrderStatusService orderStatusService);
        void Handle(IOrderStatusService orderStatusService);
    }
}
