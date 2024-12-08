using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reposetories
{
    public class CategoryReposetory : ICategoryReposetory
    {
        _214416448WebApiContext categoryContext;

        public CategoryReposetory(_214416448WebApiContext _214416448WebApiContext)
        {
            categoryContext = _214416448WebApiContext;
        }
        public async Task<List<Category>> getAllCategories()
        {
            return await categoryContext.Categories.ToListAsync();
        }
    }
}
