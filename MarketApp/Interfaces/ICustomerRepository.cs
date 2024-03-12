using MarketApp.Models;

namespace MarketApp.Interfaces
{
    public interface ICustomerRepository
    {
        List<Customer> GetAll();
        Customer GetById(int id);
        void Add(Customer obj);
        void Update(Customer obj);
        void Delete(int id);
    }
}
