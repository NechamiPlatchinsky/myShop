using Entities;

namespace Reposetories
{
    public interface ICategoryReposetory
    {
        Task<List<Category>> getAllCategories();
    }
}