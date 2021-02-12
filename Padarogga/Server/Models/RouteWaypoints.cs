using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Padarogga.Server.Models
{
    public class RouteWaypoints
    {
        public Guid WaypointId { get; set; }

        public Waypoint Waypoint { get; set; }

        public Guid RouteId { get; set; }

        public Route Route { get; set; }

        public int Order { get; set; }
    }
}
