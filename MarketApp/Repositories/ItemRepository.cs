﻿using MarketApp.Context;
using MarketApp.Interfaces;
using MarketApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketApp.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly DatabaseContext _databaseContext;

        public ItemRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void Add(Item item)
        {
            _databaseContext.Items.Add(item);
            _databaseContext.SaveChanges();
        }

        public void Delete(int itemId)
        {
            var item = GetById(itemId);
            if (item != null)
            {
                _databaseContext.Items.Remove(item);
                _databaseContext.SaveChanges();
            }
        }

        public List<Item> GetAll()
        {
            return _databaseContext.Items.ToList();
        }

        public Item GetById(int itemId)
        {
            return _databaseContext.Items.FirstOrDefault(x => x.ItemId == itemId);
        }

        public void Update(Item item)
        {
            _databaseContext.Items.Update(item);
            _databaseContext.SaveChanges();
        }
    }
}
