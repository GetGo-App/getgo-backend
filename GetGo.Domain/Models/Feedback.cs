using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetGo.Domain.Models
{
    public class Feedback
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;
        public string Content { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedDate { get; set; }

        public Feedback(string content, string userId)
        {
            Id = ObjectId.GenerateNewId().ToString();
            Content = content;
            UserId = userId;
            CreatedDate = DateTime.Now;
        }
    }
}
