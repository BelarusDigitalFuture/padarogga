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

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public Author Author { get; set; }

        public Guid AuthorId { get; set; }

        public int Duration { get; set; }

        public Difficulty Difficulty { get; set; }

        public ICollection<Waypoint> Waypoints { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<CustomerRating> Ratings { get; set; }

        public ICollection<Favorites> Favorites { get; set; }

        public ICollection<RoutePayment> Payments { get; set; }
    }
}
