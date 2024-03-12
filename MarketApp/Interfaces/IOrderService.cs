using MarketApp.Models;

namespace MarketApp.Interfaces
{
    public interface IOrderService
    {
        List<Order> GetAll();
        Order GetById(int id);
        void Add(Order obj);
        void Update(Order obj);
        void Delete(int id);
    }
}
