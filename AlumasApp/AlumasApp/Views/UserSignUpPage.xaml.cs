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
    public partial class UserSignUpPage : ContentPage
    {
        UserViewModel viewmodel;
        public UserSignUpPage()
        {
            InitializeComponent();
            BindingContext = viewmodel = new UserViewModel();

            LoadUserRolesAsync();
        }
        //funcion que permite la carga de los roles de usuario
        private async void LoadUserRolesAsync()
        {
            PkrUserRole.ItemsSource = await viewmodel.GetUserRolesAsync();
        }

        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            //capturar el rol que se haya seleccionado en el picker

            UserRole SelectedUserRole = PkrUserRole.SelectedItem as UserRole;

            bool R = await viewmodel.AddUserAsync(TxtEmail.Text.Trim(),
                                                  TxtPassword.Text.Trim(),
                                                  TxtName.Text.Trim(),
                                                  TxtBackUpEmail.Text.Trim(),
                                                  TxtPhoneNumber.Text.Trim(),
                                                  TxtAddress.Text.Trim(),
                                                  SelectedUserRole.UserRoleId);

            if (R)
            {
                await DisplayAlert(":0", "El usuario ha sido creado correctamente!", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert(":(", "Algo salio mal...", "OK");
            }
        }

        private async void BtnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}