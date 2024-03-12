using MarketApp.Interfaces;
using MarketApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketApp.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public void Add(Item item)
        {
            _itemRepository.Add(item);
        }

        public void Delete(int itemId)
        {
            _itemRepository.Delete(itemId);
        }

        public List<Item> GetAll()
        {
            return _itemRepository.GetAll();
        }

        public Item GetById(int itemId)
        {
            return _itemRepository.GetById(itemId);
        }

        public void Update(Item item)
        {
            _itemRepository.Update(item);
        }
    }
}
