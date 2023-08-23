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
    public partial class PasswordManagmentPage : ContentPage
    {
        UserViewModel viewModel;
        public PasswordManagmentPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new UserViewModel();

            LoadUserInfo();
        }
        private void LoadUserInfo()
        {
            TxtPassword.Text = GlobalObjects.MyLocalUser.Contrasennia;





        }

        private async void BtnUpdate_Clicked(object sender, EventArgs e)
        {
            //primero hacemos validacion de campos requeridos

            //primero hacemos validación de campos requeridos 

            if (ValidateFields())
            {
                //sacar un respaldo del usuario global tal y como está en este momento 
                //por si algo sale mal en el proceso de update, reversar los cambios 
                UserDTO BackupLocaluser = new UserDTO();
                BackupLocaluser = GlobalObjects.MyLocalUser;

                try
                {
                    GlobalObjects.MyLocalUser.Contrasennia = TxtNewPassword.Text.Trim();

                    var answer = await DisplayAlert("???", "Estas seguro de modificar la contrseña?", "Yes", "No");

                    if (answer)
                    {
                        bool R = await viewModel.UpdatePassword(GlobalObjects.MyLocalUser);

                        if (R)
                        {
                            await DisplayAlert(":)", "La contraseña ha sido Actualizada!!!", "OK");
                            await Navigation.PopAsync();
                        }
                        else
                        {
                            await DisplayAlert(":(", "Algo salio Mal...", "OK");
                            await Navigation.PopAsync();
                        }

                    }

                }
                catch (Exception)
                {
                    //si algo sale mal reversamos los cambios 
                    GlobalObjects.MyLocalUser = BackupLocaluser;
                    throw;
                }



            }
        }
        private bool ValidateFields()
        {
            bool R = false;
            if (TxtNewPassword.Text != null && !string.IsNullOrEmpty(TxtNewPassword.Text.Trim()) &&
                TxtConfirmNewPassword.Text != null && !string.IsNullOrEmpty(TxtConfirmNewPassword.Text.Trim())
)
            {
                //en este caso están todos los datos requeridos 

                R = true;
            }
            else
            {
                //si falta algún  dato obligatorio 
                if (TxtNewPassword.Text == null || string.IsNullOrEmpty(TxtNewPassword.Text.Trim()))
                {
                    DisplayAlert("Validacion Fallida!", "Se requiere digitar la nueva contraseña", "OK");
                    TxtNewPassword.Focus();
                    return false;
                }
                //si falta algún  dato obligatorio 
                if (TxtConfirmNewPassword.Text == null || string.IsNullOrEmpty(TxtConfirmNewPassword.Text.Trim()))
                {
                    DisplayAlert("Validacion Fallida!", "Se requiere confirmar la nueva contraseña", "OK");
                    TxtConfirmNewPassword.Focus();
                    return false;
                }


            }

            return R;
        }

        private async void BtnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}