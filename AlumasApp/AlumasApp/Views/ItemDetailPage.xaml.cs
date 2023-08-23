using AlumasApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace AlumasApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}