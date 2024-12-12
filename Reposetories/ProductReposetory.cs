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
        public async Task<List<Product>> getAllProduct()
        {
            return await productDBContext.Products.Include(a => a.Category).ToListAsync();
        }
        public async Task<Product> getProductById(int id)
        {
            return await productDBContext.Products.Include(a=>a.Category).FirstOrDefaultAsync(product => product.Id == id);
        }
    }
}
