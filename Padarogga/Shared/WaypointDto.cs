using System;
using System.Collections.Generic;
using System.Text;

namespace Padarogga.Shared
{
   public  class WaypointDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<string> ImageUrls { get; set; }

        public string MediaUrl { get; set; }      

    }
}
