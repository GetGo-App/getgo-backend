using AutoMapper;
using GetGo.Domain.Models;
using GetGo.Domain.Payload.Request.Message;
using GetGo.Repository.Interfaces;
using GetGo_BE.Services.Interfaces;

namespace GetGo_BE.Services.Implements
{
    public class AIMessageHistoryService : BaseService<AIMessageHistoryService>, IAIMessageHistoryService
    {
        private readonly IAIMessageHistoryRepository _aIMessageHistoryRepository;

        public AIMessageHistoryService(ILogger<AIMessageHistoryService> logger, IMapper mapper, IHttpContextAccessor httpContextAccessor, IAIMessageHistoryRepository aIMessageHistoryRepository) : base(logger, mapper, httpContextAccessor)
        {
            _aIMessageHistoryRepository = aIMessageHistoryRepository;
        }

        public async Task CreateAIMessageHistory(AIMessageHistory aIMessageHistory)
        {
            await _aIMessageHistoryRepository.CreateAIMessageHistory(aIMessageHistory);
        }

        public async Task<AIChatRequest> GetAIChatHistory(GetDialogMessageRequest request)
        {
            List<AIMessageHistory> history = await _aIMessageHistoryRepository.GetAIChatHistory(request);

            List<HistoryRequest> historyList = new List<HistoryRequest>();

            foreach(AIMessageHistory message in history)
            {
                historyList.Add(new HistoryRequest(message.Question, message.Answer));
            }

            return new AIChatRequest(historyList);
        }
    }
}
