using MarketApp.Models;

namespace MarketApp.Interfaces
{
    public interface IProductService
    {
        Product GetProductById(int productId);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int productId);
    }
}
