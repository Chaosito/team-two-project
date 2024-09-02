using KartowkaMarkowkaHub.Core.Domain;
using System.Security.Principal;

namespace KartowkaMarkowkaHub.Services.OrderStatuses
{
    public class StatusInProcess : IOrderStatus
    {
        public StatusType StatusType => StatusType.InProcess;
        private readonly IPrincipal principal = Thread.CurrentPrincipal ?? throw new Exception("User is not authenticated!");

        public void Handle(IOrderStatusService orderStatusService)
        {
            // Сохранить информацию о товаре на момент заказа
            // Обновить доступность товара для продажи, все ли продано (закончилось количество, объем)
            // Уведомить фермера о заказе
            // уведомление клиента
            throw new NotImplementedException();
        }

        public void NextStatus(IOrderStatusService orderStatusService)
        {
            if (principal.IsInRole("Fermer"))
            {
                orderStatusService.Status = new StatusReadyToReceive();
                //возможен переключение статуса на отменён, если товар нет или испорчен
            }
        }
    }
}