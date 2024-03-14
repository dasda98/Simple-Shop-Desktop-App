using MarketApp.Context;
using MarketApp.Interfaces;
using MarketApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketApp.Services
{
    internal class OrderItemService : IOrderItemService
    {
        private readonly DatabaseContext _databaseContext;

        public OrderItemService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void Add(OrderItem orderItem)
        {
            _databaseContext.OrderItems.Add(orderItem);
            _databaseContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var orderItem = GetById(id);
            if (orderItem != null)
            {
                _databaseContext.OrderItems.Remove(orderItem);
                _databaseContext.SaveChanges();
            }
        }

        public List<OrderItem> GetAll()
        {
            return _databaseContext.OrderItems.ToList();
        }

        public OrderItem GetById(int id)
        {
            return _databaseContext.OrderItems.FirstOrDefault(x => x.ItemId == id);
        }

        public void Update(OrderItem orderItem)
        {
            _databaseContext.OrderItems.Update(orderItem);
            _databaseContext.SaveChanges();
        }
    }
}
