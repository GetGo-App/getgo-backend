using GetGo.Domain.Models;
using GetGo.Domain.Payload.Request.Message;
using GetGo.Repository.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetGo.Repository.Implements
{
    public class AIMessageHistoryRepository : BaseRepository<AIMessageHistoryRepository>, IAIMessageHistoryRepository
    {
        private readonly IMongoCollection<AIMessageHistory> _messageHistory;

        public AIMessageHistoryRepository(IOptions<MongoDBSettings> setting) : base(setting)
        {
            _messageHistory = _database.GetCollection<AIMessageHistory>("AIMessageHistory");
        }

        public async Task<List<AIMessageHistory>> GetAIChatHistory(GetDialogMessageRequest request)
        {
            return await _messageHistory.Find(x => x.User1.Equals(request.User1) && x.User2.Equals(request.User2))
                                 .SortByDescending(x => x.Timestamp).Limit(3).ToListAsync();
        }

        public async Task CreateAIMessageHistory(AIMessageHistory message) 
        {
            await _messageHistory.InsertOneAsync(message);
        }
    }
}
