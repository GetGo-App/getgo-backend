using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace GetGo.Domain.Models
{
    public partial class Image
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;
        public string? ImageUrl { get; set; }
        public string? Uploader { get; set; }
        public DateTime? UploadedTime { get; set; }
        public string PrivacyMode { get; set; }

        public Image(string? imageUrl, string? uploader, string privacyMode)
        {
            Id = ObjectId.GenerateNewId().ToString();
            ImageUrl = imageUrl;
            Uploader = uploader;
            PrivacyMode = privacyMode;
            UploadedTime = DateTime.UtcNow;
        }
    }
}
