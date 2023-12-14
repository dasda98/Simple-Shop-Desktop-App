using MarketApp.Interfaces;
using MarketApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketApp.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public Product GetProductById(int productId)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
