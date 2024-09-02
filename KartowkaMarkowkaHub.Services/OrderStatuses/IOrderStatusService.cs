using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartowkaMarkowkaHub.Services.OrderStatuses
{
    public interface IOrderStatusService
    {
        IOrderStatus Status { get; set; }
        void SetNextStatus();

        string GetStatusName();
    }
}
