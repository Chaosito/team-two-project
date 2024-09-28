using KartowkaMarkowkaHub.Core.Domain;
using KartowkaMarkowkaHub.Services.Orders;

namespace KartowkaMarkowkaHub.Services.OrderStatuses
{
    public class StatusInProcess : IOrderStatus
    {
        public StatusType StatusType => StatusType.InProcess;

        public void Handle(IOrderStatusService orderStatusService)
        {
            // Сохранить информацию о товаре на момент заказа
            // Обновить доступность товара для продажи, все ли продано (закончилось количество, объем)
            // Уведомить фермера о заказе
            // уведомление клиента
            throw new NotImplementedException();
        }

        public StatusType NextStatus(IOrderStatusService orderStatusService)
        {
            if (true)
            {
                orderStatusService.Status = new StatusReadyToReceive();
                //возможен переключение статуса на отменён, если товар нет или испорчен
            }
            return orderStatusService.Status.StatusType;
        }
    }
}