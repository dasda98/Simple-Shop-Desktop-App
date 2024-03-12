using MarketApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketApp.Interfaces
{
    public interface IOrderItemRepository
    {
        List<OrderItem> GetAll();
        OrderItem GetById(int id);
        void Add(OrderItem obj);
        void Update(OrderItem obj);
        void Delete(int id);
    }
}
