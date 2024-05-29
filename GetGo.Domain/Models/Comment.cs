using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetGo.Domain.Models
{
    public class Comment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;
        public string Content { get; set; }
        public List<string> Images { get; set; }
        public float Rating { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Location {  get; set; }

        public Comment(string content, List<string> images, float rating, string userId, string location)
        {
            Id = ObjectId.GenerateNewId().ToString();
            Content = content;
            Images = images;
            Rating = rating;
            UserId = userId;
            Location = location;
            CreatedDate = DateTime.Now;
        }
    }
}
