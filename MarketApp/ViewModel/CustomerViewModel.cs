using MarketApp.Helpers;
using MarketApp.Interfaces;
using MarketApp.Models;
using System.Collections.ObjectModel;

namespace MarketApp.ViewModel
{
    public class CustomerViewModel : ViewModelBase
    {
        private readonly ICustomerService _customerService;

        private ObservableCollection<Customer> _customers;
        public ObservableCollection<Customer> Customers { 
            get {  return _customers; }
            set {
                if (value != _customers)
                {
                    _customers = value;
                    OnPropertyChanged(nameof(Customers));
                }
            }
        }

        public CustomerViewModel(ICustomerService customerService) {
            _customerService = customerService;
            LoadCustomers();
        }

        private void LoadCustomers()
        {
            _customers = new ObservableCollection<Customer>(_customerService.GetAllCustomers());
        }
    }
}
