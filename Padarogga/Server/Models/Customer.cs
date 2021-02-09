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

        public ICollection<CustomerRating> Ratings { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<Favorites> Favorites { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<RoutePayment> Payments { get; set; }
    }
}
