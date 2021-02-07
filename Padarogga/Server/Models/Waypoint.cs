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

        public string ImageUrl { get; set; }

        public string MediaUrl { get; set; }

        public Guid RouteId { get; set; }

        public Route Route { get; set; }

        [Column(TypeName = "geometry (point)")]
        public Point Location { get; set; }
    }
}
