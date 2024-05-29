using AutoMapper;
using GetGo.Domain.Models;
using GetGo.Domain.Payload.Request.Message;
using GetGo.Repository.Interfaces;
using GetGo_BE.Services.Interfaces;

namespace GetGo_BE.Services.Implements
{
    public class MessageService : BaseService<MessageService>, IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        public MessageService(ILogger<MessageService> logger, IMapper mapper, IHttpContextAccessor httpContextAccessor, IMessageRepository messageRepository) : base(logger, mapper, httpContextAccessor)
        {
            _messageRepository = messageRepository;
        }

        public async Task CreateMessage(CreateMessageRequest request)
        {
            await _messageRepository.CreateMessage(request);
        }

        public async Task DeleteMessage(string id)
        {
            await _messageRepository.DeleteMessage(id);
        }

        public async Task<List<Message>> GetUserMessageHistory(GetDialogMessageRequest request)
        {
            return await _messageRepository.GetUserMessageHistory(request);
        }
    }
}
