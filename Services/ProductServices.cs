using Entities;
using Reposetories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductServices : IProductServices
    {
        IProductReposetory productrReposetory;
        public ProductServices(IProductReposetory _productReposetory)
        {
            productrReposetory = _productReposetory;
        }
        public async Task<List<Product>> getAllProduct(int? position, int? skip, string? desc, int? minPrice, int? maxPrice, int?[] categoryIds)
        {
            return await productrReposetory.getAllProduct(position, skip, desc, minPrice, maxPrice, categoryIds);
        }
        public async Task<Product> getProductById(int id)
        {
            return await productrReposetory.getProductById(id);
        }
    }
}
