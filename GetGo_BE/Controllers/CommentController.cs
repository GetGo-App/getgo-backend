using GetGo.Domain.Payload.Request.Comment;
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
    public class CommentController : BaseController<CommentController>
    {
        private readonly ICommentService _commentService;

        public CommentController(ILogger<CommentController> logger, ICommentService commentService) : base(logger)
        {
            _commentService = commentService;
        }

        [HttpPost(ApiEndPointConstant.Comment.CommentsEndpoint)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Create a comment")]
        public async Task<IActionResult> CreateComment(CreateCommentRequest request)
        {
            await _commentService.CreateComment(request);
            return Ok("Action success");
        }
    }
}
