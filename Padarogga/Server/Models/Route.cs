using Padarogga.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Padarogga.Server.Models
{
    public class Route: BaseEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int TypeId { get; set; }

        public RouteType Type { get; set; }

        public Customer Customer { get; set; }

        public Guid CusomerId { get; set; }

        public TimeSpan Duration { get; set; }

        public List<string> Images { get; set; }

        public Difficulty Difficulty { get; set; }

        public ICollection<RouteWaypoints> Waypoints { get; set; }

        public ICollection<RouteComment> Comments { get; set; }

        public ICollection<RouteRating> Ratings { get; set; }

        public ICollection<FavoriteRoute> Favorites { get; set; }

        public ICollection<RoutePayment> Payments { get; set; }
    }
}
