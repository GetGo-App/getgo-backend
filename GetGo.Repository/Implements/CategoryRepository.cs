using GetGo.Domain.Models;
using GetGo.Repository.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetGo.Repository.Implements
{
    public class CategoryRepository : BaseRepository<CategoryRepository>, ICategoryRepository
    {
        private readonly IMongoCollection<Category> _categories;

        public CategoryRepository(IOptions<MongoDBSettings> setting) : base(setting)
        {
            _categories = _database.GetCollection<Category>("Category");
        }

        public async Task<List<Category>> GetCategoryList()
        {
            return await _categories.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<Category> GetCategoryById(string id)
        {
            return await _categories.Find(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task UpdateCategory(Category category)
        {
            Category currentCate = await _categories.Find(c => c.Id == category.Id).FirstOrDefaultAsync();

            currentCate.Name = String.IsNullOrEmpty(category.Name) ? currentCate.Name : category.Name;

            await _categories.ReplaceOneAsync(c => c.Id == category.Id, currentCate);
        }

        public async Task CreateCategory(string name)
        {
            Category category = new Category(name);
            await _categories.InsertOneAsync(category);
        }
    }
}
