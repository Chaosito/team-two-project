using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartowkaMarkowkaHub.Core.Domain
{
    public class OrderStatus: BaseEntity
    {
        public string Name { get; set; }

        public StatusType StatusType { get; set; }
    }

    public enum StatusType
    {
        Created = 1,

        InProcess = 2,

        Completed = 3
    }
}
