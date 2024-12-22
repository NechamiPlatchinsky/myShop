using Entities;

namespace Reposetories
{
    public interface IProductReposetory
    {
        Task<List<Product>> getAllProduct(int? position, int? skip, string? desc, int? minPrice, int? maxPrice, int?[] categoryIds);
        Task<Product> getProductById(int id);
    }
}