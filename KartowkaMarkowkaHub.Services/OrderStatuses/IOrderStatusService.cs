using KartowkaMarkowkaHub.Core.Domain;

namespace KartowkaMarkowkaHub.Services.OrderStatuses
{
    public interface IOrderStatusService
    {
        IOrderStatus Status { get; set; }
        StatusType SetNextStatus();

        string GetStatusName();
    }
}
