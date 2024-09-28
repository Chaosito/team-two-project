using KartowkaMarkowkaHub.Core.Domain;

namespace KartowkaMarkowkaHub.Services.OrderStatuses
{
    public class StatusCreated : IOrderStatus
    {
        public StatusType StatusType => StatusType.Created;

        public void Handle(IOrderStatusService orderService)
        {
            //уведомление клиента
            throw new NotImplementedException();
        }

        public StatusType NextStatus(IOrderStatusService orderStatusService)
        {
            orderStatusService.Status = new StatusInProcess();
            return orderStatusService.Status.StatusType;
        }
    }
}