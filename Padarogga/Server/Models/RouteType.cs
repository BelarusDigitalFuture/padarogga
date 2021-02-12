using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Padarogga.Server.Models
{
    public class RouteType
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Route> Routes { get; set; }
    }
}
