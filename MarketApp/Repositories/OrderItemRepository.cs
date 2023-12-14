using MarketApp.Context;
using MarketApp.Interfaces;
using MarketApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketApp.Repositories
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly DatabaseContext _databaseContext;

        public OrderItemRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public OrderItem GetById(int id)
        {
            return _databaseContext.OrderItems.FirstOrDefault(c => c.OrderItemId == id);
        }

        public void AddOrderItem(OrderItem orderItem)
        {
            _databaseContext.OrderItems.Add(orderItem);
            _databaseContext.SaveChanges();
        }

        public void UpdateOrderItem(OrderItem orderItem)
        {
            _databaseContext.OrderItems.Update(orderItem);
            _databaseContext.SaveChanges();
        }

        public void DeleteOrderItem(int id)
        {
            var orderItem = GetById(id);
            if (orderItem != null)
            {
                _databaseContext.OrderItems.Remove(orderItem);
                _databaseContext.SaveChanges();
            }
        }
    }
}
