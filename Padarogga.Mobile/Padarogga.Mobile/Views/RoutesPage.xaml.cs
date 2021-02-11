using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Padarogga.Mobile.Models;
using Padarogga.Mobile.Views;
using Padarogga.Mobile.ViewModels;
using Padarogga.Shared;
using Xamarin.Forms.Maps;

namespace Padarogga.Mobile.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class RoutesPage : ContentPage
    {
        RoutesViewModel viewModel;

        public RoutesPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new RoutesViewModel();           
        }

        async void OnItemSelected(object sender, EventArgs args)
        {
            var layout = (BindableObject)sender;
            var item = (RouteDto)layout.BindingContext;
            await Navigation.PushAsync(new RouteDetailPage(new RouteDetailViewModel(item)));
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Routes.Count == 0)
                viewModel.IsBusy = true;
        }
    }
}