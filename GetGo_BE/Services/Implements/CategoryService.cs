using AutoMapper;
using GetGo.Domain.Models;
using GetGo.Repository.Interfaces;
using GetGo_BE.Services.Interfaces;

namespace GetGo_BE.Services.Implements
{
    public class CategoryService : BaseService<CategoryService>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ILogger<CategoryService> logger, IMapper mapper, IHttpContextAccessor httpContextAccessor, ICategoryRepository categoryRepository) 
            : base(logger, mapper, httpContextAccessor)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task CreateCategory(string name)
        {
            await _categoryRepository.CreateCategory(name);
        }

        public async Task<Category> GetCategoryById(string id)
        {
            return await _categoryRepository.GetCategoryById(id);
        }

        public async Task<List<Category>> GetCategoryList()
        {
            return await _categoryRepository.GetCategoryList();
        }

        public async Task UpdateCategory(Category category)
        {
            await _categoryRepository.UpdateCategory(category);
        }
    }
}
