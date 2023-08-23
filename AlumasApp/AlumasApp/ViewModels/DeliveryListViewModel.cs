using AlumasApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace AlumasApp.ViewModels
{
    public class DeliveryListViewModel :BaseViewModel
    {
        public Delivery MyDelivery { get; set; }
        public DeliveryListViewModel()
        {
            MyDelivery = new Delivery();

        }
        public async Task<ObservableCollection<Delivery>> GetDeliveriesAsync(int pClientID)
        {
            if (IsBusy) return null;
            IsBusy = true;

            try
            {

                ObservableCollection<Delivery> deliveries = new ObservableCollection<Delivery>();

                MyDelivery.ClientsClientId = pClientID;

                deliveries = await MyDelivery.GetDeliveyListByClientID();

                if (deliveries == null)
                {
                    return null;
                }
                return deliveries;
            }
            catch (Exception)
            {
                return null;

                throw;
            }

        }
    }
}
