using AlumasApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace AlumasApp.ViewModels
{
    public class EmployeesListViewModel :BaseViewModel
    {
        public Employee MyEmployee { get; set; }
        public EmployeesListViewModel()
        {
            MyEmployee = new Employee();


        }
        //funciones del vm

        public async Task<ObservableCollection<Employee>> GetEmployeesAsync(int pBranchID)
        {
            if (IsBusy) return null;
            IsBusy = true;

            try
            {

                ObservableCollection<Employee> employees = new ObservableCollection<Employee>();

                MyEmployee.BranchBranchId = pBranchID;

                employees = await MyEmployee.GetEmployeeListByBranchID();

                if (employees == null)
                {
                    return null;
                }
                return employees;
            }
            catch (Exception)
            {
                return null;

                throw;
            }

        }
    }
}