using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Padarogga.Shared
{
    public class AddRouteModel
    {
        public AddRouteModel()
        {
            Waypoints = new List<AddWaypointModel>();
        }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public int Duration { get; set; }

        public DurationPeriod DurationPeriod { get; set; }

        public int TypeId { get; set; }       

        public Difficulty Difficulty { get; set; }

        public List<AddWaypointModel> Waypoints { get; set; }
    }

    public enum DurationPeriod
    {
        [Display(Name = "Часы")]
        Hours,
        [Display(Name = "Дни")]
        Days,
        [Display(Name = "Месяцы")]
        Month
    }
}
