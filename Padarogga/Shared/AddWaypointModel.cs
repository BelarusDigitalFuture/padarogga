﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Padarogga.Shared
{
    public class AddWaypointModel
    {
        public string Name { get; set; }

        public string Description { get; set; }      

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string ImageUrl { get; set; }

        public string MediaUrl { get; set; }
    }
}
