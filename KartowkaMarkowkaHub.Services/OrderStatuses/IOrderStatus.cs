using KartowkaMarkowkaHub.Core.Domain;

namespace KartowkaMarkowkaHub.Services.OrderStatuses
{
    public interface IOrderStatus
    {
        public StatusType StatusType { get; }
        public void NextStatus(IOrderStatusService orderStatusService);
        public void Handle(IOrderStatusService orderStatusService);
    }
}
