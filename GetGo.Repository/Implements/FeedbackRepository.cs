using GetGo.Domain.Models;
using GetGo.Domain.Payload.Request.Feedback;
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
    public class FeedbackRepository : BaseRepository<FeedbackRepository>, IFeedbackRepository
    {
        private readonly IMongoCollection<Feedback> _feedbacks;

        public FeedbackRepository(IOptions<MongoDBSettings> setting) : base(setting)
        {
            _feedbacks = _database.GetCollection<Feedback>("Feedback");
        }

        public async Task<List<Feedback>> GetAllFeedbacks()
        {
            return await _feedbacks.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<Feedback> GetFeedbackById(string id)
        {
            return await _feedbacks.Find(f => f.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateFeedback(CreateFeedbackRequest request)
        {
            Feedback feedback = new Feedback(request.Content, request.UserId);
            await _feedbacks.InsertOneAsync(feedback);
        }
    }
}
