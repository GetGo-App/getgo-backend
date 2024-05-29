using GetGo.Domain.Models;

namespace GetGo_BE.Services.Interfaces
{
    public interface ICategoryService
    {
        public Task<List<Category>> GetCategoryList();
        public Task<Category> GetCategoryById(string id);
        public Task UpdateCategory(Category category);
        public Task CreateCategory(string name);
    }
}
