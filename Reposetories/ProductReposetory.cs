using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reposetories
{
    public class ProductReposetory : IProductReposetory
    {
        _214416448WebApiContext productDBContext;
        public ProductReposetory(_214416448WebApiContext _214416448WebApiContext)
        {
            productDBContext = _214416448WebApiContext;
        }
        public async Task<List<Product>> getAllProduct(int? position, int? skip, string? desc, int? minPrice, int? maxPrice, int?[] categoryIds)
        {
            var query = productDBContext.Products.Where(product =>
            (desc == null ? (true) : (product.Description.Contains(desc)))
            && ((minPrice == null) ? (true) : (product.Price >= minPrice))
            && ((maxPrice == null) ? (true) : (product.Price <= maxPrice))
            && ((categoryIds.Length == 0) ? (true) : (categoryIds.Contains(product.CategoryId))))
                .OrderBy(product => product.Price).Include(a => a.Category);
            return await query.ToListAsync();
        }
        public async Task<Product> getProductById(int id)
        {
            return await productDBContext.Products.Include(a => a.Category).FirstOrDefaultAsync(product => product.Id == id);
        }
    }
}
