using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Padarogga.Mobile.Services;
using Padarogga.Mobile.Views;

namespace Padarogga.Mobile
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<RouteDataStore>();
            DependencyService.Register<MockDataStore>();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
