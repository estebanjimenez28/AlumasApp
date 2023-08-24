using AlumasApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AlumasApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeliveryListPage : ContentPage
    {

        DeliveryListViewModel deliveryListViewModel;
        public DeliveryListPage()
        {
            InitializeComponent();
            BindingContext = deliveryListViewModel = new DeliveryListViewModel();

            LoadDeliveryList();
        }
        private async void LoadDeliveryList()
        {
            GlobalObjects.MyLocalClient.ClientId = 1;
            LvList.ItemsSource = await deliveryListViewModel.GetDeliveriesAsync(GlobalObjects.MyLocalClient.ClientId);
        }
    }
}