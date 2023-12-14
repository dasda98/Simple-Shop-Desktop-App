using MarketApp.Interfaces;
using MarketApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketApp.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public void AddCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public void DeleteCustomer(int customerId)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomerById(int customerId)
        {
            throw new NotImplementedException();
        }

        public void UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
