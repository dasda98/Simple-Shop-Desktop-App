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
        OrderItem GetById(int id);
        void AddOrderItem(OrderItem orderItem);
        void UpdateOrderItem(OrderItem orderItem);
        void DeleteOrderItem(int id);
    }
}
