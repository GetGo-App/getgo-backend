using GetGo.Domain.Models;
using GetGo.Domain.Payload.Request.Status;
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
    public class StatusController : BaseController<StatusController>
    {
        private readonly IStatusService _statusService;

        public StatusController(ILogger<StatusController> logger, IStatusService statusService) : base(logger)
        {
            _statusService = statusService;
        }

        [HttpGet(ApiEndPointConstant.Status.StatusesEndpoint)]
        [ProducesResponseType(typeof(Status), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Get all status")]
        public async Task<IActionResult> GetAllStatus()
        {
            var result = await _statusService.GetAllStatus();
            return Ok(result);
        }

        [HttpPost(ApiEndPointConstant.Status.StatusesEndpoint)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Create status")]
        public async Task<IActionResult> CreateStatus([FromBody]CreateStatusRequest request)
        {
            await _statusService.CreateStatus(request);
            return Ok("Action success");
        }

        [HttpGet(ApiEndPointConstant.Status.StatusEndpoint)]
        [ProducesResponseType(typeof(Status), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Get status by id")]
        public async Task<IActionResult> GetStatusById(string id)
        {
            var result = await _statusService.GetStatusById(id);
            return Ok(result);
        }

        [HttpGet(ApiEndPointConstant.Status.UserStatusEndpoint)]
        [ProducesResponseType(typeof(Status), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Get user status")]
        public async Task<IActionResult> GetUserStatus(string userId)
        {
            var result = await _statusService.GetUserStatus(userId);
            return Ok(result);
        }

        [HttpPatch(ApiEndPointConstant.Status.StatusEndpoint)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Update status")]
        public async Task<IActionResult> UpdateStatus(string id, [FromBody]UpdateStatusRequest request)
        {
            await _statusService.UpdateStatus(id, request);
            return Ok("Action success");
        }

        [HttpDelete(ApiEndPointConstant.Status.StatusEndpoint)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Delete status")]
        public async Task<IActionResult> DeleteStatus(string id)
        {
            await _statusService.DeleteStatus(id);
            return Ok("Action success");
        }

        [HttpPatch(ApiEndPointConstant.Status.StatusReactionEndpoint)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Update reaction in status")]
        public async Task<IActionResult> UpdateReaction(string id, [FromBody]@string request)
        {
            await _statusService.UpdateReaction(id, request);
            return Ok("Action success");
        }
    }
}
