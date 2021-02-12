using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Padarogga.Server.Models
{
    public class Waypoint : BaseEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Customer Cusomer { get; set; }

        public Guid CustomerId { get; set; }

        public List<string> Images { get; set; }

        public List<string> Video { get; set; }

        public List<string> Audio { get; set; }

        public List<string> Tags { get; set; }

        [Column(TypeName = "geometry (point)")]
        public Point Location { get; set; }

        public ICollection<RouteWaypoints> Routes { get; set; }
        public ICollection<FavoriteWaypoint> Favorites { get; set; }
        public ICollection<WaypointComment> Comments { get; set; }


    }
}
