using MarketApp.Helpers;
using MarketApp.Interfaces;
using MarketApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MarketApp.ViewModel
{
    public class OrderViewModel : ViewModelBase
    {
        private readonly ICustomerService _customerService;
        private readonly IOrderService _orderService;

        public OrderViewModel(ICustomerService customerService, IOrderService orderService)
        {
            _customerService = customerService;
            _orderService = orderService;

            LoadOrders();
            LoadCustomers();
        }

        private ObservableCollection<Customer> _customers;
        public ObservableCollection<Customer> Customers
        {
            get { return _customers; }
            set
            {
                if (value != _customers)
                {
                    _customers = value;
                    OnPropertyChanged(nameof(Customers));
                }
            }
        }

        private ObservableCollection<Order> _orders;
        public ObservableCollection<Order> Orders
        {
            get { return _orders; }
            set
            {
                if (value != _orders)
                {
                    _orders = value;
                    OnPropertyChanged(nameof(Orders));
                }
            }
        }

        private void LoadCustomers()
        {
            _customers = new ObservableCollection<Customer>(_customerService.GetAll());
        }
        private void LoadOrders()
        {
            _orders = new ObservableCollection<Order>(_orderService.GetAll());
        }

        private Customer _selectedCustomer;
        public Customer SelectedCustomer
        {
            get { return _selectedCustomer; }
            set
            {
                if (value != _selectedCustomer)
                {
                    _selectedCustomer = value;
                        
                    OnPropertyChanged(nameof(SelectedCustomer));
                }
            }
        }
    }
}
