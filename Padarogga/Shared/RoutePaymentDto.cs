using System;
using System.Collections.Generic;
using System.Text;

namespace Padarogga.Shared
{
    public class RoutePaymentDto:BaseDto
    {
        public Guid Id { get; set; }

        public Guid RouteId { get; set; }

        public string RouteName { get; set; }

        public Guid CustomerId { get; set; }

        public string CustomerName { get; set; }

        public decimal Amount { get; set; }

        public string Description { get; set; }
    }
}
