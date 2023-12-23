using MarketApp.Context;
using MarketApp.Interfaces;
using MarketApp.Models;

namespace MarketApp.Repositories
{
    public class ProductRepository : IProductRepository
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
