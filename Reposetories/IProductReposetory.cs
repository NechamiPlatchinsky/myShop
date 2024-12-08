using Entities;

namespace Reposetories
{
    public interface IProductReposetory
    {
        Task<List<Product>> getAllProduct();
        Task<Product> getProductById(int id);
    }
}