using GetGo.Domain.Models;
using GetGo.Domain.Payload.Request.Story;

namespace GetGo_BE.Services.Interfaces
{
    public interface IStoryService
    {
        public Task CreateStory(CreateStoryRequest request);
        public Task<List<Story>> GetUserStories(string userId);
        public Task<Story> GetStoryById(string id);
        public Task<List<Story>> GetAllStories();
        public Task DeleteStory(string id);
        public Task UpdateStory(string id, UpdateStoryRequest request);
    }
}
