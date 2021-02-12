using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Padarogga.Server.Models
{
    public class WaypointComment : Comment
    {
        public Guid WaypointId { get; set; }

        public Waypoint Waypoint { get; set; }
    }
}
