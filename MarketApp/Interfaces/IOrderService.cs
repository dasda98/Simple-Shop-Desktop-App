using MarketApp.Models;

namespace MarketApp.Interfaces
{
    public interface IOrderService
    {
        Order GetOrderById(int orderId);
        void AddOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(int orderId);
    }
}
