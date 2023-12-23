using MarketApp.Models;

namespace MarketApp.Interfaces
{
    public interface IOrderRepository
    {
        Order GetById(int id);
        void AddOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(int id);
    }
}
