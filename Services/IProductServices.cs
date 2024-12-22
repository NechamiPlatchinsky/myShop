using Entities;

namespace Services
{
    public interface IProductServices
    {
        Task<List<Product>> getAllProduct(int? position, int? skip, string? desc, int? minPrice, int? maxPrice, int?[] categoryIds);
        Task<Product> getProductById(int id);
    }
}