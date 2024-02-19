using MarketApp.Helpers;
using MarketApp.Interfaces;
using MarketApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml.Linq;

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

        public ICommand AddCustomerCommand { get; }
        public ICommand DeleteCustomerCommand { get; }
        public ICommand EditCustomerCommand { get; }

        public CustomerViewModel(ICustomerService customerService) {
            _customerService = customerService;
            LoadCustomers();

            AddCustomerCommand = new RelayCommand(AddCustomer, CanAddCustomer);
            DeleteCustomerCommand = new RelayCommand(DeleteCustomer);
            EditCustomerCommand = new RelayCommand(EditCustomer);
        }

        private void LoadCustomers()
        {
            _customers = new ObservableCollection<Customer>(_customerService.GetAllCustomers());
        }

        private string _firstName;
        private string _lastName;
        private string _email;
        private string _phoneNumber;

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    OnPropertyChanged(nameof(FirstName));
                }
            }
        }
        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    OnPropertyChanged(nameof(LastName));
                }
            }
        }
        public string Email
        {
            get { return _email; }
            set
            {
                if (_email != value)
                {
                    _email = value;
                    OnPropertyChanged(nameof(Email));
                }
            }
        }
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                if (_phoneNumber != value)
                {
                    _phoneNumber = value;
                    OnPropertyChanged(nameof(PhoneNumber));
                }
            }
        }

        private void AddCustomer(object parameter)
        {
            Customer newCustomer = new Customer { FirstName=FirstName, LastName=LastName, Email=Email, PhoneNumber=PhoneNumber };
            _customerService.AddCustomer(newCustomer);
            _customers.Add(newCustomer);

            FirstName = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
            PhoneNumber = string.Empty;
        }

        private bool CanAddCustomer(object parameter)
        {
            bool isFirstName = string.IsNullOrEmpty(FirstName);
            bool isLastName = string.IsNullOrEmpty(LastName);
            bool isEmail = string.IsNullOrEmpty(Email);
            bool isPhone = string.IsNullOrEmpty(PhoneNumber);

            if (!isFirstName && !isLastName && !isEmail && !isPhone) { 
                return true;
            } else
            {
                return false;
            }
        }

        private void DeleteCustomer(object parameter)
        {
            _customerService.DeleteCustomer(_selectedCustomer.CustomerId);
            _customers.Remove(_selectedCustomer);
        }

        private Customer _selectedCustomer;
        public Customer SelectedCustomer
        {
            get { return _selectedCustomer; }
            set
            {
                if (_selectedCustomer != value)
                {
                    _selectedCustomer = value;
                    OnPropertyChanged(nameof(SelectedCustomer));
                    FillBoxSelectedCustomer(_selectedCustomer);
                }
            }
        }

        private void FillBoxSelectedCustomer(Customer customer)
        {
            if (customer != null)
            {
                FirstName = customer.FirstName;
                LastName = customer.LastName;
                Email = customer.Email;
                PhoneNumber = customer.PhoneNumber;
            }
        }

        private void EditCustomer(object parameter)
        {
            _customerService.UpdateCustomer(_selectedCustomer);
            LoadCustomers();
        }
    }
}
