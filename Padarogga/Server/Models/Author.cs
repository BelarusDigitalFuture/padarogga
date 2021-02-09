using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Padarogga.Server.Models
{
    public class Author : BaseEntity
    {
        public Guid Id { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public ICollection<Route> Routes { get; set; }

        public decimal Balance { get; set; }
    }
}
