using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Padarogga.Mobile.Models;
using Padarogga.Mobile.ViewModels;
using Padarogga.Shared;
using Xamarin.Forms.Maps;

namespace Padarogga.Mobile.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class RouteDetailPage : ContentPage
    {
        RouteDetailViewModel viewModel;

        public RouteDetailPage(RouteDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;

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

        public RouteDetailPage()
        {
            InitializeComponent();

            var item = new RouteDto
            {
                Name = "Item 1",
                Description = "This is an item description."
            };

            viewModel = new RouteDetailViewModel(item);
            BindingContext = viewModel;
        }
    }
}