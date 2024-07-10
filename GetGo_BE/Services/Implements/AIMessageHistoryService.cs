using AutoMapper;
using GetGo.Domain.Models;
using GetGo.Domain.Payload.Request.Message;
using GetGo.Repository.Interfaces;
using GetGo_BE.Enums.Message;
using GetGo_BE.Services.Interfaces;
using Org.BouncyCastle.Asn1.Ocsp;

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
            List<HistoryRequest> history = await _aIMessageHistoryRepository.GetAIChatHistory(request);

            return new AIChatRequest(history);
        }

        public async Task<List<HistoryRequest>> GetAIChatHistory(string userId)
        {
            return await _aIMessageHistoryRepository.GetAIChatHistory(new GetDialogMessageRequest
            {
                User1 = userId,
                User2 = AIChatEnum.CHATAGENT.ToString(),
            });
        }
    }
}
