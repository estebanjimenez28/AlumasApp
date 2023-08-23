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
    public partial class EmployeeManagmentPage : ContentPage
    {
        UserViewModel viewmodel;
        public EmployeeManagmentPage()
        {
            InitializeComponent();
            BindingContext = viewmodel = new UserViewModel();

            LoadBranchAsync();
        }
        private async void LoadBranchAsync()
        {
            PkrBranch.ItemsSource = await viewmodel.GetBranchAsync();
        }

        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            //capturar el rol que se haya seleccionado en el picker

            Branch SelectedBranch = PkrBranch.SelectedItem as Branch;

            bool R = await viewmodel.AddEmployeeAsync(
              
                                                  TxtEmployeeName.Text.Trim(),
                                                  TxtBackUpEmail.Text.Trim(),
                                                  TxtPhoneNumber.Text.Trim(),
                                                  TxtAddress.Text.Trim(),
                                                  SelectedBranch.BranchId);

            if (R)
            {
                await DisplayAlert(":0", "Empleado creado correctamente!", "OK");
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