﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Padarogga.Server.Models
{
    public class Favorites : BaseEntity
    {
        public Guid CustomerId { get; set; }

        public Customer Customer { get; set; }

        public Guid RouteId { get; set; }

        public Route Route { get; set; }
    }
}
