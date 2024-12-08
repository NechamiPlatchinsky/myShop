using Entities;
using Reposetories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CategoryServices : ICategoryServices
    {
        private ICategoryReposetory categoryReposetory;

        public CategoryServices(ICategoryReposetory _ICategoryReposetory)
        {
            categoryReposetory = _ICategoryReposetory;
        }
        public async Task<List<Category>> getAllCategories()
        {
            return await categoryReposetory.getAllCategories();
        }
    }
}
