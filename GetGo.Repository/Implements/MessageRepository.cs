using GetGo.Domain.Models;
using GetGo.Domain.Payload.Request.Message;
using GetGo.Repository.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetGo.Repository.Implements
{
    public class MessageRepository : BaseRepository<MessageRepository>, IMessageRepository
    {
        private readonly IMongoCollection<Message> _messages;
        public MessageRepository(IOptions<MongoDBSettings> setting) : base(setting)
        {
            _messages = _database.GetCollection<Message>("Message");
        }

        public async Task CreateMessage(CreateMessageRequest request)
        {
            Message message = new Message(request.User1, request.User2, request.Timestamp, request.Content);

            await _messages.InsertOneAsync(message);
        }

        public async Task<List<Message>> GetUserMessageHistory(GetDialogMessageRequest request)
        {
            return await _messages.Find(m => m.User1 == request.User1 && m.User2 == request.User2).ToListAsync();
        }

        public async Task DeleteMessage(string id)
        {
            FilterDefinition<Message> filterDefinition = Builders<Message>.Filter.Eq("Id", id);
            await _messages.DeleteOneAsync(filterDefinition);
        }
    }
}
