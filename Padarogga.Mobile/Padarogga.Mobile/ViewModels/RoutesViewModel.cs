using Padarogga.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Padarogga.Mobile.ViewModels
{
    public class RoutesViewModel : BaseViewModel
    {
        public Command LoadItemsCommand { get; set; }
        public ObservableCollection<RouteDto> Routes { get; set; }

        public RoutesViewModel()
        {
            Routes = new ObservableCollection<RouteDto>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());           
        }
       

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Routes.Clear();
                var items = await RouteStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Routes.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
