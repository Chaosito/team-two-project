using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartowkaMarkowkaHub.Core.Domain
{
    public class Role: BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<UserRole> Users { get; set; }
    }
}
