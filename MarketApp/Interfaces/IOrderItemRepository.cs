using MarketApp.Models;

namespace MarketApp.Interfaces
{
    public interface IOrderItemRepository
    {
        OrderItem GetById(int id);
        void AddOrderItem(OrderItem orderItem);
        void UpdateOrderItem(OrderItem orderItem);
        void DeleteOrderItem(int id);
    }
}
