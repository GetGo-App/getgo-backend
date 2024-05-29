using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetGo.Domain.Models
{
    public class Message
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;
        public string User1 {  get; set; }
        public string User2 { get; set; }
        public DateTime Timestamp { get; set; }
        public string Content { get; set; }

        public Message(string user1, string user2, DateTime timestamp, string content)
        {
            Id = ObjectId.GenerateNewId().ToString();
            User1 = user1;
            User2 = user2;
            Timestamp = timestamp;
            Content = content;
        }
    }
}
