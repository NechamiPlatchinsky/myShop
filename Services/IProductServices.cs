using Entities;

namespace Services
{
    public interface IProductServices
    {
        Task<List<Product>> getAllProduct();
        Task<Product> getProductById(int id);
    }
}