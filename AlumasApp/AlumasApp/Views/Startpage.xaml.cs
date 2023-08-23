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
    public partial class Startpage : ContentPage
    {
        public Startpage()
        {
            InitializeComponent();
            LoadUserName();

        }
        private void LoadUserName()
        {
            LblUserName.Text = GlobalObjects.MyLocalUser.Nombre.ToUpper();

        }


        private async void BtnUserManagment_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UserManagmentPage());
        }

       

        private async void BtnPasswordManagment_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PasswordManagmentPage());
        }

     



        private async void BtnClientsManagment_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ClientManagmentPage());

        }

        private async void BtnEmployeesManagment_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EmployeeManagmentPage());
        }

        private async void BtnRoutesManagment_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DeliveryManagmentPage());
        }

        private async void BtnProductsManagment_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProductManagmentPage());
        }


        private async void BtnEmployeeList_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EmployeeListPage());
        }

        private async void BtnDeliveryList_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DeliveryListPage());
        }
    }
}