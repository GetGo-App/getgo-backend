using GetGo.Domain.Models;
using GetGo.Domain.Payload.Request.Message;
using GetGo.Domain.Payload.Request.Route;
using GetGo.Domain.Payload.Response.Messages;
using GetGo_BE.Constants;
using GetGo_BE.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson.IO;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;
using System.Text;

namespace GetGo_BE.Controllers
{
    [Authorize]
    [ApiController]
    public class MessageController : BaseController<MessageController>
    {
        private readonly IMessageService _messageService;
        private readonly IMapService _mapService;
        public MessageController(ILogger<MessageController> logger, IMessageService messageService, IMapService mapService) : base(logger)
        {
            _messageService = messageService;
            _mapService = mapService;
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

        [HttpPost(ApiEndPointConstant.Message.AIChatMessageEndpoint)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Get location suggestion from ai")]
        public async Task<IActionResult> AIChat(string question, string userId)
        {
            try
            {
                var result = new LocationSuggestionMessageResponse();
                using (var httpClient = new HttpClient())
                {
                    AIChatRequest aIChatRequest = new AIChatRequest(question);
                    aIChatRequest.history.Add(new HistoryRequest("test", ""));
                    var content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(aIChatRequest), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync("http://127.0.0.1:8000/agents/chat-agent", content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var responseContent = await response.Content.ReadAsStringAsync();
                            result = Newtonsoft.Json.JsonConvert.DeserializeObject<LocationSuggestionMessageResponse>(responseContent);
                        }
                    }
                }

                //Add new Map
                await _mapService.CreateMap(new CreateMapRequest(userId, result.ids_location));

                return Ok("Action Success");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
