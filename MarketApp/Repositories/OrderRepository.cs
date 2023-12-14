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
    public class OrderRepository : IOrderRepository
    {
        private readonly DatabaseContext _databaseContext;

        public OrderRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public Order GetById(int id)
        {
            return _databaseContext.Orders.FirstOrDefault(c => c.OrderId == id);
        }

        public void AddOrder(Order order)
        {
            _databaseContext.Orders.Add(order);
            _databaseContext.SaveChanges();
        }

        public void UpdateOrder(Order order)
        {
            _databaseContext.Orders.Update(order);
            _databaseContext.SaveChanges();
        }

        public void DeleteOrder(int id)
        {
            var order = GetById(id);
            if (order != null)
            {
                _databaseContext.Orders.Remove(order);
                _databaseContext.SaveChanges();
            }
        }
    }
}
