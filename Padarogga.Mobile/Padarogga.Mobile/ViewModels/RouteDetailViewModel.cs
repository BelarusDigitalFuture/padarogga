using Padarogga.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Padarogga.Mobile.ViewModels
{
    public class RouteDetailViewModel : BaseViewModel
    {
        public RouteDto Item { get; set; }
        public RouteDetailViewModel(RouteDto item = null)
        {
            Title = item?.Name;
            Item = item;
        }
    }
}
