using MarketApp.Models;

namespace MarketApp.Interfaces
{
    public interface IOrderItemService
    {
        OrderItem GetOrderItemById(int orderItemId);
        void AddOrderItem(OrderItem orderItem);
        void UpdateOrderItem(OrderItem orderItem);
        void DeleteOrderItem(int orderItemId);
    }
}
