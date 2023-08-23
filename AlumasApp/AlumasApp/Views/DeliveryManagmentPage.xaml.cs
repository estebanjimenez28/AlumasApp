using AlumasApp.Models;
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
    public partial class DeliveryManagmentPage : ContentPage
    {
        UserViewModel viewmodel;
        public DeliveryManagmentPage()
        {
            InitializeComponent();
            BindingContext = viewmodel = new UserViewModel();

            LoadClientAsync();
        }
        private async void LoadClientAsync()
        {
            PkrClient.ItemsSource = await viewmodel.GetClientAsync();
        }

        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            //capturar el cliente que se haya seleccionado en el picker

            Client SelectedClient = PkrClient.SelectedItem as Client;

            bool R = await viewmodel.AddDeliveryAsync(
                                                  TxtAddress.Text.Trim(),
                                                  TxtDescription.Text.Trim(),
                                                  SelectedClient.ClientId);

            if (R)
            {
                await DisplayAlert(":0", "Lugar de entrega creado correctamente!", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert(":(", "Algo Salio Mal...", "OK");
            }

        }

        private async void BtnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}