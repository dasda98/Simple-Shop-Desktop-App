using MarketApp.Context;
using MarketApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace MarketApp.Views
{
    /// <summary>
    /// Interaction logic for CustomerPage.xaml
    /// </summary>
    public partial class CustomerPage : Page
    {
        private ObservableCollection<Customer> _customers;

        public ObservableCollection<Customer> Customers { 
            get => _customers; 
            set
            {
                _customers = value;
            } 
        }

        public CustomerPage()
        {
            DataContext = this;
            var _context = new DatabaseContext();

            _customers = new ObservableCollection<Customer>(_context.Customers.ToList());


            InitializeComponent();
        }
    }
}
