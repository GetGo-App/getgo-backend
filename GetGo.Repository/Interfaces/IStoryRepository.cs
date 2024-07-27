using GetGo.Domain.Models;
using GetGo.Domain.Payload.Request.Status;
using GetGo.Domain.Payload.Request.Story;
using GetGo.Domain.Payload.Request.User;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetGo.Repository.Interfaces
{
    public interface IStoryRepository
    {
        public Task CreateStory(CreateStoryRequest request);
        public Task<List<Story>> GetUserStories(string userId);   
        public Task<Story> GetStoryById(string id);
        public Task<List<Story>> GetAllStories();
        public Task DeleteStory(string id);
        public Task UpdateStory(string id, UpdateStoryRequest request);

        public Task UpdateReaction(string id, User reactedUser);
    }
}
