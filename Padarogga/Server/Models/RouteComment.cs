using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Padarogga.Server.Models
{
    public class RouteComment : Comment
    {
        public Guid RouteId { get; set; }

        public Route Route { get; set; }
    }
}
