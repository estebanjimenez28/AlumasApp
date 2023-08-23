using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlumasApp.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AlumasApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmployeeListPage : ContentPage
    {
        EmployeesListViewModel employeeslistViewModel;
        public EmployeeListPage()
        {
            InitializeComponent();

            BindingContext = employeeslistViewModel = new EmployeesListViewModel();

            LoadEmployeeList();
        }
        private async void LoadEmployeeList()
        {
            LvList.ItemsSource = await employeeslistViewModel.GetEmployeesAsync(GlobalObjects.MyLocaBranch.BranchId);
        }
    }
}