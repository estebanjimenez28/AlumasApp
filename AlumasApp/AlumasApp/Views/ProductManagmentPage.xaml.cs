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
    public partial class ProductManagmentPage : ContentPage
    {
        UserViewModel viewmodel;
        public ProductManagmentPage()
        {
            InitializeComponent();
            BindingContext = viewmodel = new UserViewModel();

            LoadProductCategoryAsync();
        }
        private async void LoadProductCategoryAsync()
        {
            PkrProductCategory.ItemsSource = await viewmodel.GetProductCategoriesAsync();
        }

    

    private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            //capturar el rol que se haya seleccionado en el picker

            ProductCategory SelectedProductCategory = PkrProductCategory.SelectedItem as ProductCategory;

            bool R = await viewmodel.AddProductAsync(
                                                  TxtProductName.Text.Trim(),
                                                  TxtQuantity.Text.Trim(),
                                    
                                                  TxtIdBranch.Text.Trim(),
                                                  TxtIdCliente.Text.Trim(), 
                                                  SelectedProductCategory.ProductCategoryId);

            if (R)
            {
                await DisplayAlert(":0", "Producto creado correctamente!", "OK");
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