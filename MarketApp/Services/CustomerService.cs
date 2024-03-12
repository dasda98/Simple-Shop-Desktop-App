using MarketApp.Interfaces;
using MarketApp.Models;

namespace MarketApp.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public void Add(Customer customer)
        {
            _customerRepository.Add(customer);
        }

        public void Delete(int customerId)
        {
            _customerRepository.Delete(customerId);
        }

        public List<Customer> GetAll()
        {
            return _customerRepository.GetAll();
        }

        public Customer GetById(int customerId)
        {
            return _customerRepository.GetById(customerId);
        }

        public void Update(Customer customer)
        {
            _customerRepository.Update(customer);
        }
    }
}
