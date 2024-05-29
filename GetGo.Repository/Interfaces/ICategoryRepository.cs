using GetGo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetGo.Repository.Interfaces
{
    public interface ICategoryRepository
    {
        public Task<List<Category>> GetCategoryList();
        public Task<Category> GetCategoryById(string id);
        public Task UpdateCategory(Category category);
        public Task CreateCategory(string name);
    }
}
