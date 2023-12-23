using MarketApp.Models;

namespace MarketApp.Interfaces
{
    public interface IProductRepository
    {
        Product GetById(int id);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int id);
    }
}
