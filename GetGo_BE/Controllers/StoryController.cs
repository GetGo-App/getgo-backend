using GetGo.Domain.Models;
using GetGo.Domain.Payload.Request.Message;
using GetGo.Domain.Payload.Request.Story;
using GetGo_BE.Constants;
using GetGo_BE.Services.Implements;
using GetGo_BE.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GetGo_BE.Controllers
{
    [Authorize]
    [ApiController]
    public class StoryController : BaseController<StoryController>
    {
        private readonly IStoryService _storyService;

        public StoryController(ILogger<StoryController> logger, IStoryService storyService) : base(logger)
        {
            _storyService = storyService;
        }

        [HttpPost(ApiEndPointConstant.Story.StoriesEndpoint)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Create story")]
        public async Task<IActionResult> CreatStory([FromBody] CreateStoryRequest request)
        {
            await _storyService.CreateStory(request);
            return Ok("Action success");
        }

        [HttpGet(ApiEndPointConstant.Story.UserStoriesEndpoint)]
        [ProducesResponseType(typeof(List<Story>), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Get user stories")]
        public async Task<IActionResult> GetUserStories(string userId)
        {
            var result = await _storyService.GetUserStories(userId);
            return Ok(result);
        }

        [HttpGet(ApiEndPointConstant.Story.StoryEndpoint)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Get story by id")]
        public async Task<IActionResult> GetStoryById(string id)
        {
            var result = await _storyService.GetStoryById(id);
            return Ok(result);
        }

        [HttpPatch(ApiEndPointConstant.Story.StoriesEndpoint)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Update story")]
        public async Task<IActionResult> UpdateStory(string id, [FromBody] UpdateStoryRequest request)
        {
            await _storyService.UpdateStory(id, request);
            return Ok("Action success");
        }

        [HttpDelete(ApiEndPointConstant.Story.StoriesEndpoint]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Delete Story")]
        public async Task<IActionResult> DeleteStory(string id)
        {
            await _storyService.DeleteStory(id);
            return Ok("Action success");
        }
    }
}
