using GetGo.Domain.Models;
using GetGo.Domain.Payload.Request.Message;

namespace GetGo_BE.Services.Interfaces
{
    public interface IAIMessageHistoryService
    {
        public Task CreateAIMessageHistory(AIMessageHistory aIMessageHistory);
        public Task<AIChatRequest> GetAIChatHistory(GetDialogMessageRequest request);
    }
}
