using GetGo.Domain.Models;
using GetGo.Domain.Payload.Request.Message;
using GetGo.Domain.Payload.Request.Route;
using GetGo.Domain.Payload.Response.Messages;
using GetGo_BE.Constants;
using GetGo_BE.Enums.Message;
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
        private readonly IAIMessageHistoryService _aiMessageHistoryService;

        public MessageController(ILogger<MessageController> logger, IMessageService messageService, IMapService mapService, IAIMessageHistoryService aiMessageHistoryService) : base(logger)
        {
            _messageService = messageService;
            _mapService = mapService;
            _aiMessageHistoryService = aiMessageHistoryService;
        }

        [HttpPost(ApiEndPointConstant.Message.MessagesEndpoint)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Create message")]
        public async Task<IActionResult> CreateMessage([FromBody] CreateMessageRequest request)
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
        public async Task<IActionResult> GetDialogMessage([FromBody] GetDialogMessageRequest request)
        {
            var result = await _messageService.GetUserMessageHistory(request);
            return Ok(result);
        }

        [HttpPost(ApiEndPointConstant.Message.AIChatMessageEndpoint)]
        [ProducesResponseType(typeof(LocationSuggestionMessageResponse), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Get location suggestion from ai")]
        public async Task<IActionResult> AIChat(string question, string userId)
        {
            try
            {
                //Create MessageHistory
                AIMessageHistory message = new AIMessageHistory(userId, AIChatEnum.CHATAGENT.ToString(), DateTime.Now, question);

                var result = new LocationSuggestionMessageResponse();
                using (var httpClient = new HttpClient())
                {
                    //Initialize chat history and question
                    AIChatRequest request = await _aiMessageHistoryService.GetAIChatHistory(new GetDialogMessageRequest()
                    {
                        User1 = userId,
                        User2 = AIChatEnum.CHATAGENT.ToString()
                    });
                    request.question = question;

                    var content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

                    httpClient.DefaultRequestHeaders.Add("X-API-Key", "ZjFkOTk2MDQtOTUwMi00OTk3LWE4MWEtODc2N2E2MTc1YjM5");
                    using (var response = await httpClient.PostAsync("https://pphuc25-getgo-ai.hf.space/agents/chat-agent", content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var responseContent = await response.Content.ReadAsStringAsync();
                            result = Newtonsoft.Json.JsonConvert.DeserializeObject<LocationSuggestionMessageResponse>(responseContent);
                        }
                    }
                }

                //Add AI message to message history
                if(result.text != null)
                {
                    message.Answer = result.text;
                }

                //Add new Map
                if (result.ids_location != null)
                {
                    await _mapService.CreateMap(new CreateMapRequest(userId, result.ids_location));
                }

                //Create message history
                await _aiMessageHistoryService.CreateAIMessageHistory(message);

                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
