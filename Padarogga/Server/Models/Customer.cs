using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Padarogga.Server.Models
{
    public class Customer : BaseEntity
    {
        public Guid Id { get; set; }

        public ApplicationUser User { get; set; }

        public string UserId { get; set; }

        public ICollection<RouteRating> Ratings { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<Route> Routes { get; set; }

        public ICollection<FavoriteRoute> FavoriteRoutes { get; set; }

        public ICollection<FavoriteWaypoint> FavoriteWaypoints { get; set; }

        public ICollection<RouteComment> RouteComments { get; set; }

        public ICollection<WaypointComment> WaypointComments { get; set; }

        public ICollection<RoutePayment> Payments { get; set; }
    }
}
