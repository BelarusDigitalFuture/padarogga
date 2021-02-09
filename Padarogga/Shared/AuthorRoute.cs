using System;
using System.Collections.Generic;
using System.Text;

namespace Padarogga.Shared
{
    public class AuthorRoute
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }       

        public Guid AuthorId { get; set; }

        public int Duration { get; set; }

        public Difficulty Difficulty { get; set; }

        public int Waypoints { get; set; }

        public int Rating { get; set; }

        public int Comments { get; set; }

        public int Favorites { get; set; }

        public decimal Payments { get; set; }
    }
}
