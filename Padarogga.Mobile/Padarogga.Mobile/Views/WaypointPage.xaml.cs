using Padarogga.Mobile.ViewModels;
using Padarogga.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace Padarogga.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WaypointPage : ContentPage
    {

        WaypointViewModel viewModel;

        public WaypointPage()
        {
            InitializeComponent();


            BindingContext = viewModel = new WaypointViewModel();

            //
            var position = new Position(53.451166, 26.473357);
            MapSpan mapSpan = MapSpan.FromCenterAndRadius(position, Distance.FromKilometers(0.444));
            map.MoveToRegion(mapSpan);

            var pin = new Pin()
            {
                Position = position,
                Label = "Мирский замок"
            };

            map.Pins.Add(pin);

          
        }








    }
}