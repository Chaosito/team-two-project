using KartowkaMarkowkaHub.Core.Domain;

namespace KartowkaMarkowkaHub.Services.OrderStatuses
{
    public class StatusCanceled : IOrderStatus
    {
        public StatusType StatusType => StatusType.Canceled;
        public void Handle(IOrderStatusService orderStatusService)
        {
            throw new NotImplementedException();
        }

        public StatusType NextStatus(IOrderStatusService orderStatusService)
        {
            throw new NotImplementedException();
        }
    }
}
