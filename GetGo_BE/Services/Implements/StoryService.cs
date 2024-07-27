using AutoMapper;
using GetGo.Domain.Models;
using GetGo.Domain.Payload.Request.Status;
using GetGo.Domain.Payload.Request.Story;
using GetGo.Repository.Interfaces;
using GetGo_BE.Services.Interfaces;

namespace GetGo_BE.Services.Implements
{
    public class StoryService : BaseService<StoryService>, IStoryService
    {
        private readonly IStoryRepository _storyRepository;
        private readonly IUserRepository _userRepository;

        public StoryService(ILogger<StoryService> logger, IMapper mapper, IHttpContextAccessor httpContextAccessor,
            IStoryRepository storyRepository, IUserRepository userRepository) : base(logger, mapper, httpContextAccessor)
        {
            _storyRepository = storyRepository;
            _userRepository = userRepository;
        }

        public async Task CreateStory(CreateStoryRequest request)
        {
            await _storyRepository.CreateStory(request);
        }

        public async Task DeleteStory(string id)
        {
            await _storyRepository.DeleteStory(id);
        }

        public async Task<List<Story>> GetAllStories()
        {
            return await _storyRepository.GetAllStories();
        }

        public async Task<Story> GetStoryById(string id)
        {
            return await _storyRepository.GetStoryById(id);
        }

        public async Task<List<Story>> GetUserStories(string userId)
        {
            return await _storyRepository.GetUserStories(userId);
        }

        public async Task UpdateStory(string id, UpdateStoryRequest request)
        {
            await _storyRepository.UpdateStory(id, request);
        }

        public async Task UpdateReaction(string id, StoryReactionRequest request)
        {
            User reactedUser = await _userRepository.GetUserById(request.ReactedUserId);

            await _storyRepository.UpdateReaction(id, reactedUser);
        }

        public async Task<List<User>> GetReactedUsersInStory(string id)
        {
            Story story = await _storyRepository.GetStoryById(id);

            List<User> users = await _userRepository.GetUserByIdList(story.ReactedUsers);
            return users;
        }
    }
}
