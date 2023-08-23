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
    public partial class UserManagmentPage : ContentPage
    {
        UserViewModel viewModel;
        public UserManagmentPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new UserViewModel();

            LoadUserInfo();
        }
        private void LoadUserInfo()
        {
            TxtID.Text = GlobalObjects.MyLocalUser.IDUsuario.ToString();
            TxtEmail.Text = GlobalObjects.MyLocalUser.Correo;
            TxtName.Text = GlobalObjects.MyLocalUser.Nombre;
            TxtPhoneNumber.Text = GlobalObjects.MyLocalUser.Telefono;
            TxtBackUpEmail.Text = GlobalObjects.MyLocalUser.CorreoRespaldo;
            TxtAddress.Text = GlobalObjects.MyLocalUser.Direccion;



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
                    GlobalObjects.MyLocalUser.Nombre = TxtName.Text.Trim();
                    GlobalObjects.MyLocalUser.CorreoRespaldo = TxtBackUpEmail.Text.Trim();
                    GlobalObjects.MyLocalUser.Telefono = TxtPhoneNumber.Text.Trim();
                    GlobalObjects.MyLocalUser.Direccion = TxtAddress.Text.Trim();

                    var answer = await DisplayAlert("???", "Estás seguro de odificar la informacion?", "Si", "No");

                    if (answer)
                    {
                        bool R = await viewModel.UpdateUser(GlobalObjects.MyLocalUser);

                        if (R)
                        {
                            await DisplayAlert(":)", "Usuario Modificado!!!", "OK");
                            await Navigation.PopAsync();
                        }
                        else
                        {
                            await DisplayAlert(":(", "Algo Salió mal...", "OK");
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

            if (TxtName.Text != null && !string.IsNullOrEmpty(TxtName.Text.Trim()) &&
                TxtBackUpEmail.Text != null && !string.IsNullOrEmpty(TxtBackUpEmail.Text.Trim()) &&
                TxtPhoneNumber.Text != null && !string.IsNullOrEmpty(TxtPhoneNumber.Text.Trim()))
            {
                //en este caso están todos los datos requeridos 

                R = true;
            }
            else
            {
                //si falta algún  dato obligatorio 
                if (TxtName.Text == null || string.IsNullOrEmpty(TxtName.Text.Trim()))
                {
                    DisplayAlert("Validacion Fallida!", "El nombre es requerido", "OK");
                    TxtName.Focus();
                    return false;
                }

                if (TxtBackUpEmail.Text == null || string.IsNullOrEmpty(TxtBackUpEmail.Text.Trim()))
                {
                    DisplayAlert("Validacion Fallida!", "El correo de respaldo es requerido", "OK");
                    TxtBackUpEmail.Focus();
                    return false;
                }

                if (TxtPhoneNumber.Text == null || string.IsNullOrEmpty(TxtPhoneNumber.Text.Trim()))
                {
                    DisplayAlert("Validacion Fallida!", "El numero telefonico es requerido", "OK");
                    TxtPhoneNumber.Focus();
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