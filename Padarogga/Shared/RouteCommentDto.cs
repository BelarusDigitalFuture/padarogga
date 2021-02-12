using System;
using System.Collections.Generic;
using System.Text;

namespace Padarogga.Shared
{
    public class RouteCommentDto : BaseDto
    {
        public Guid Id { get; set; }

        public string Text { get; set; }

        public Guid CustomerId { get; set; }

        public string CustomerName { get; set; }

        public Guid RouteId { get; set; }
    }
}
