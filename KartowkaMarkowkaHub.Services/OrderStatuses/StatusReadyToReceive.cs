using KartowkaMarkowkaHub.Core.Domain;
using System.Security.Principal;

namespace KartowkaMarkowkaHub.Services.OrderStatuses
{
    public class StatusReadyToReceive : IOrderStatus
    {
        public StatusType StatusType => StatusType.ReadyToReceive;
        private readonly IPrincipal principal = Thread.CurrentPrincipal ?? throw new Exception("User is not authenticated!");

        public void Handle(IOrderStatusService orderStatusService)
        {
            throw new NotImplementedException();
        }

        public void NextStatus(IOrderStatusService orderStatusService)
        {
            if (principal.IsInRole("Customer"))
            {
                orderStatusService.Status = new StatusCompleted();
            }
        }
    }
}