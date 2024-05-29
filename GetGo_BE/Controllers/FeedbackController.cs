using GetGo.Domain.Models;
using GetGo.Domain.Payload.Request.Feedback;
using GetGo_BE.Constants;
using GetGo_BE.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GetGo_BE.Controllers
{
    [Authorize]
    [ApiController]
    public class FeedbackController : BaseController<FeedbackController>
    {
        private readonly IFeedbackService _feedbackService;

        public FeedbackController(ILogger<FeedbackController> logger, IFeedbackService feedbackService) : base(logger)
        {
            _feedbackService = feedbackService;
        }

        [HttpGet(ApiEndPointConstant.Feedback.FeedbacksEndpoint)]
        [ProducesResponseType(typeof(List<Feedback>), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Get feedback list")]
        public async Task<IActionResult> GetFeedbackList()
        {
            var result = await _feedbackService.GetAllFeedbacks();
            return Ok(result);
        }

        [HttpGet(ApiEndPointConstant.Feedback.FeedbackEndpoint)]
        [ProducesResponseType(typeof(Feedback), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Get a feedback by id")]
        public async Task<IActionResult> GetFeedbackById(string id)
        {
            var result = await _feedbackService.GetFeedbackById(id);
            return Ok(result);
        }

        [HttpPost(ApiEndPointConstant.Feedback.FeedbacksEndpoint)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Create feedback")]
        public async Task<IActionResult> CreateFeedback(CreateFeedbackRequest request)
        {
            await _feedbackService.CreateFeedback(request);
            return Ok("Action success");
        }
    }
}
