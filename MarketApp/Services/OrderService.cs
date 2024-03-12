using MarketApp.Interfaces;
using MarketApp.Models;

namespace MarketApp.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public void Add(Order order)
        {
            _orderRepository.Add(order);
        }

        public void Delete(int orderId)
        {
            _orderRepository.Delete(orderId);
        }

        public List<Order> GetAll()
        {
            return _orderRepository.GetAll();
        }

        public Order GetById(int orderId)
        {
            return _orderRepository.GetById(orderId);
        }

        public void Update(Order order)
        {
            _orderRepository.Update(order);
        }
    }
}
