using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Padarogga.Server.Models
{
    public class FavoriteWaypoint : BaseEntity
    {
        public Guid CustomerId { get; set; }

        public Customer Customer { get; set; }

        public Guid WaypointId { get; set; }

        public Waypoint Waypoint { get; set; }
    }
}
