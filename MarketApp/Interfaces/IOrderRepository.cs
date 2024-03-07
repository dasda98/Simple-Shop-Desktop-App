using MarketApp.Models;

namespace MarketApp.Interfaces
{
    public interface IOrderRepository
    {
        List<Order> GetAllOrders();
        Order GetById(int orderId);
        void AddOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(int orderId);
    }
}
