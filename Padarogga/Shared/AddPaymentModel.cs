using System;
using System.Collections.Generic;
using System.Text;

namespace Padarogga.Shared
{
    public class AddPaymentModel
    {
        public Guid RouteId { get; set; }

        public Guid CustomerId { get; set; }

        public decimal Amount { get; set; }

        public string Description { get; set; }
    }
}
