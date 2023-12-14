using MarketApp.Interfaces;
using MarketApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            throw new NotImplementedException();
        }

        public void DeleteOrderItem(int orderItemId)
        {
            throw new NotImplementedException();
        }

        public OrderItem GetOrderItemById(int orderItemId)
        {
            throw new NotImplementedException();
        }

        public void UpdateOrderItem(OrderItem orderItem)
        {
            throw new NotImplementedException();
        }
    }
}
