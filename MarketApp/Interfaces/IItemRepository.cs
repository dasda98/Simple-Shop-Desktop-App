using MarketApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketApp.Interfaces
{
    public interface IItemRepository
    {
        List<Item> GetAll();
        Item GetById(int id);
        void Add(Item obj);
        void Update(Item obj);
        void Delete(int id);
    }
}
