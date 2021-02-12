using System;
using System.Collections.Generic;
using System.Text;

namespace Padarogga.Shared
{
    public class AddRouteCommentModel
    {
        public string Text { get; set; }

        public Guid CustomerId { get; set; }    

        public Guid RouteId { get; set; }       
    }
}
