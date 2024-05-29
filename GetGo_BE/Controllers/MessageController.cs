using GetGo.Domain.Models;
using GetGo.Domain.Payload.Request.Message;
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
    public class MessageController : BaseController<MessageController>
    {
        private readonly IMessageService _messageService;
        public MessageController(ILogger<MessageController> logger, IMessageService messageService) : base(logger)
        {
            _messageService = messageService;
        }

        [HttpPost(ApiEndPointConstant.Message.MessagesEndpoint)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Create message")]
        public async Task<IActionResult> CreateMessage([FromBody]CreateMessageRequest request)
        {
            await _messageService.CreateMessage(request);
            return Ok("Action success");
        }

        [HttpDelete(ApiEndPointConstant.Message.MessageEndpoint)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Delete message")]
        public async Task<IActionResult> DeleteMessage(string id)
        {
            await _messageService.DeleteMessage(id);
            return Ok("Action success");
        }

        [HttpPost(ApiEndPointConstant.Message.DialogMessagesEndpoint)]
        [ProducesResponseType(typeof(List<Message>), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Get message history list")]
        public async Task<IActionResult> GetDialogMessage([FromBody]GetDialogMessageRequest request)
        {
            var result = await _messageService.GetUserMessageHistory(request);
            return Ok(result);
        }
    }
}
