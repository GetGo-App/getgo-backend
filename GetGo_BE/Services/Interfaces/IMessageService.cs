using GetGo.Domain.Models;
using GetGo.Domain.Payload.Request.Message;

namespace GetGo_BE.Services.Interfaces
{
    public interface IMessageService
    {
        public Task CreateMessage(CreateMessageRequest request);
        public Task<List<Message>> GetUserMessageHistory(GetDialogMessageRequest request);
        public Task DeleteMessage(string id);
    }
}
