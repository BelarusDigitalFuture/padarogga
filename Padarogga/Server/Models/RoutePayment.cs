using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Padarogga.Server.Models
{
    public class RoutePayment : BaseEntity
    {
        public Guid Id { get; set; }

        public Guid RouteId { get; set; }

        public Route Route { get; set; }

        public Guid CustomerId { get; set; }

        public Customer Customer { get; set; }

        public decimal Amount { get; set; }

        public string Description { get; set; }
    }
}
