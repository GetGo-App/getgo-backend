using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetGo.Domain.Models
{
    public class AIMessageHistory
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;
        public string User1 { get; set; }
        public string User2 { get; set; }
        public DateTime Timestamp { get; set; }
        public string Question { get; set; }
        public string? Answer { get; set; }

        public AIMessageHistory(string user1, string user2, DateTime timestamp, string question)
        {
            Id = ObjectId.GenerateNewId().ToString();
            User1 = user1;
            User2 = user2;
            Timestamp = timestamp;
            Question = question;
            Answer = String.Empty;
        }

        public AIMessageHistory()
        {
            Id = ObjectId.GenerateNewId().ToString();
        }
    }
}
