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

        public void NextStatus(IOrderStatusService orderService)
        {
            orderService.Status = new StatusInProcess();
        }
    }
}