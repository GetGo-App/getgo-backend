using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetGo.Domain.Models
{
    public class Story
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;
        public string Creator { get; set; }
        public string Content { get; set; }
        public string Caption { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ExpiredAt { get; set;}

        public Story(string creator, string content, string caption)
        {
            Id = ObjectId.GenerateNewId().ToString();
            Creator = creator;
            Content = content;
            Caption = caption;
            CreatedAt = DateTime.Now;
            ExpiredAt = DateTime.Now.AddDays(2);
        }
    }
}
