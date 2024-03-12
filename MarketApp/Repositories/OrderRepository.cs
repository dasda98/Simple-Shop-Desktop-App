using MarketApp.Context;
using MarketApp.Interfaces;
using MarketApp.Models;

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

        public void Add(Order order)
        {
            _databaseContext.Orders.Add(order);
            _databaseContext.SaveChanges();
        }

        public void Update(Order order)
        {
            _databaseContext.Orders.Update(order);
            _databaseContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var order = GetById(id);
            if (order != null)
            {
                _databaseContext.Orders.Remove(order);
                _databaseContext.SaveChanges();
            }
        }
        public List<Order> GetAll()
        {
            return _databaseContext.Orders.ToList();
        }
    }
}
