using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartowkaMarkowkaHub.Core.Domain
{
    public class Basket : BaseEntity
    {
        public Guid ClientId { get; set; }

        public Client Client { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
