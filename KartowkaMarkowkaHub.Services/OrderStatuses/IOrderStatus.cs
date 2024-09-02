using KartowkaMarkowkaHub.Core.Domain;
using KartowkaMarkowkaHub.Services.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartowkaMarkowkaHub.Services.OrderStatuses
{
    public interface IOrderStatus
    {
        public StatusType StatusType { get; }
        public void NextStatus(IOrderStatusService orderStatusService);
        public void Handle(IOrderStatusService orderStatusService);

        //protected void UpdateStatus(int orderId);
    }


}
