using MarketApp.Models;

namespace MarketApp.Interfaces
{
    public interface IOrderService
    {
        List<Order> GetAllOrders();
        Order GetOrderById(int orderId);
        void AddOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(int orderId);
    }
}
