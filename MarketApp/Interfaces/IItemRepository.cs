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
        List<Item> GetAllItems();
        Item GetItemById(int itemId);
        void AddItem(Item item);
        void UpdateItem(Item item);
        void DeleteItem(int itemId);
    }
}
