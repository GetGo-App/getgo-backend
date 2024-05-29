using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetGo.Domain.Models
{
    public class Status
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;
        public string Content { get; set; }
        public List<string> Images { get; set; }
        public string Uploader {  get; set; }
        public DateTime UploadedTime { get; set; }
        public string PrivacyMode { get; set; }
        public List<string> ReactedUsers { get; set; }

        public Status(string content, List<string> images, string uploader, string privacyMode)
        {
            Id = ObjectId.GenerateNewId().ToString();
            Content = content;
            Images = images;
            Uploader = uploader;
            PrivacyMode = privacyMode;
            UploadedTime = DateTime.Now;
        }
    }
}
