using Amazon.Runtime.Internal;
using GetGo.Domain.Models;
using GetGo.Domain.Models.Documents;
using GetGo.Domain.Payload.Request.Story;
using GetGo.Repository.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetGo.Repository.Implements
{
    public class StoryRepository : BaseRepository<StoryRepository>, IStoryRepository
    {
        private readonly IMongoCollection<Story> _stories;

        public StoryRepository(IOptions<MongoDBSettings> setting) : base(setting)
        {
            _stories = _database.GetCollection<Story>("Story");
        }

        public async Task CreateStory(CreateStoryRequest request)
        {
            Story story = new Story(request.Creator, request.Content, request.Caption);

            await _stories.InsertOneAsync(story);
        }

        public async Task<List<Story>> GetUserStories(string userId)
        {
            return await _stories.Find(m => m.Creator.Equals(userId)).ToListAsync();
        }

        public async Task<Story> GetStoryById(string id)
        {
            return await _stories.Find(m => m.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task DeleteStory(string id)
        {
            FilterDefinition<Story> filterDefinition = Builders<Story>.Filter.Eq("Id", id);
            await _stories.DeleteOneAsync(filterDefinition);
        }

        public async Task UpdateStory(string id, UpdateStoryRequest request)
        {
            Story story = await _stories.Find(st => st.Id.Equals(id)).FirstOrDefaultAsync();
            story.Caption = String.IsNullOrEmpty(request.Caption) ? story.Caption : request.Caption;
            story.Content = String.IsNullOrEmpty(request.Content) ? story.Content : request.Content;
            await _stories.ReplaceOneAsync(st => st.Id == id, story);
        }
    }
}
