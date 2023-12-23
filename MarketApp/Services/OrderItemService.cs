using MarketApp.Interfaces;
using MarketApp.Models;

namespace MarketApp.Services
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepository _orderItemRepository;

        public OrderItemService(IOrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }

        public void AddOrderItem(OrderItem orderItem)
        {
            _orderItemRepository.AddOrderItem(orderItem);
        }

        public void DeleteOrderItem(int orderItemId)
        {
            _orderItemRepository.DeleteOrderItem(orderItemId);
        }

        public OrderItem GetOrderItemById(int orderItemId)
        {
            return _orderItemRepository.GetById(orderItemId);
        }

        public void UpdateOrderItem(OrderItem orderItem)
        {
            _orderItemRepository.UpdateOrderItem(orderItem);
        }
    }
}
