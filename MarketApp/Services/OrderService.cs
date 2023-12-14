using MarketApp.Interfaces;
using MarketApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketApp.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public void AddOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public void DeleteOrder(int orderId)
        {
            throw new NotImplementedException();
        }

        public Order GetOrderById(int orderId)
        {
            throw new NotImplementedException();
        }

        public void UpdateOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
