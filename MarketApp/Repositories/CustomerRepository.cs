using MarketApp.Context;
using MarketApp.Interfaces;
using MarketApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketApp.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DatabaseContext _databaseContext;

        public CustomerRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public Customer GetById(int id)
        {
            return _databaseContext.Customers.FirstOrDefault(c => c.CustomerId == id);
        }

        public void Add(Customer customer)
        {
            _databaseContext.Customers.Add(customer);
            _databaseContext.SaveChanges();
        }

        public void Update(Customer customer)
        {
            _databaseContext.Customers.Update(customer);
            _databaseContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var customer = GetById(id);
            if (customer != null)
            {
                _databaseContext.Customers.Remove(customer);
                _databaseContext.SaveChanges();
            }
        }

        public List<Customer> GetAll()
        {
            return _databaseContext.Customers.ToList();
        }
    }
}
