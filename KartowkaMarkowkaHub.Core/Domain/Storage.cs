﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartowkaMarkowkaHub.Core.Domain
{
    public class Storage : BaseEntity
    {
        public string Name { get; set; }

        public string Address { get; set; } = "";

        public string Description { get; set; } = "";
    }
}
