using AutoMapper;
using GetGo.Domain.Models;
using GetGo.Domain.Payload.Request.Message;
using GetGo.Repository.Interfaces;
using GetGo_BE.Enums.Message;
using GetGo_BE.Services.Interfaces;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Text;

namespace GetGo_BE.Services.Implements
{
    public class AIMessageHistoryService : BaseService<AIMessageHistoryService>, IAIMessageHistoryService
    {
        private readonly IAIMessageHistoryRepository _aIMessageHistoryRepository;
        private readonly ILocationRepository _locationRepository;

        public AIMessageHistoryService(ILogger<AIMessageHistoryService> logger, IMapper mapper, IHttpContextAccessor httpContextAccessor,
            IAIMessageHistoryRepository aIMessageHistoryRepository, ILocationRepository locationRepository) : base(logger, mapper, httpContextAccessor)
        {
            _aIMessageHistoryRepository = aIMessageHistoryRepository;
            _locationRepository = locationRepository;
        }

        public async Task CreateAIMessageHistory(AIMessageHistory aIMessageHistory)
        {
            await _aIMessageHistoryRepository.CreateAIMessageHistory(aIMessageHistory);
        }

        public async Task<AIChatRequest> GetAIChatHistory(GetDialogMessageRequest request)
        {
            List<HistoryRequest> history = await _aIMessageHistoryRepository.GetAIChatHistory(request);

            //Take stored AI Message History and convert into AI History request for call AI API
            var aiHistory = await ChangeHistoryToString(history);

            return new AIChatRequest(aiHistory);
        }

        public async Task<List<HistoryRequest>> GetAIChatHistory(string userId)
        {
            return await _aIMessageHistoryRepository.GetAIChatHistory(new GetDialogMessageRequest
            {
                User1 = userId,
                User2 = AIChatEnum.CHATAGENT.ToString(),
            });
        }

        private async Task<List<AIHistoryRequest>> ChangeHistoryToString(List<HistoryRequest> request)
        {
            List<AIHistoryRequest> result = new List<AIHistoryRequest>();

            //Take Message information
            foreach (var history in request)
            {
                AIHistoryRequest aiHistory = new AIHistoryRequest(history.question, String.Empty);

                if (history.answer != null)
                {
                    StringBuilder answerStr = new StringBuilder();
                    answerStr.Append(history.answer.texts_message);
                    answerStr.Append('\n');
                    if (history.answer.locations_message != null)
                    {
                        if (history.answer.locations_message.locations != null)
                        {
                            string location = await _locationRepository.GetLocationName(history.answer.locations_message.locations);
                            answerStr.Append($"Locations: {location}.");
                        }

                        answerStr.Append(history.answer.locations_message.message);
                    }

                    aiHistory.answer = answerStr.ToString();
                }
                result.Add(aiHistory);
            }

            return result;
        }
    }
}
