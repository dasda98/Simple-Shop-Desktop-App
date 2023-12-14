using MarketApp.Context;
using MarketApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketApp.Repositories
{
    public class ProductRepository
    {
        private readonly DatabaseContext _databaseContext;

        public ProductRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public Product GetById(int id)
        {
            return _databaseContext.Products.FirstOrDefault(c => c.ProductId == id);
        }

        public void AddProduct(Product product)
        {
            _databaseContext.Products.Add(product);
            _databaseContext.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            _databaseContext.Products.Update(product);
            _databaseContext.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var product = GetById(id);
            if (product != null)
            {
                _databaseContext.Products.Remove(product);
                _databaseContext.SaveChanges();
            }
        }
    }
}
