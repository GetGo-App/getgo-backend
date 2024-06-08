using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GetGo.Domain.Models.Documents;
using System.Text.Json.Serialization;

namespace GetGo.Domain.Models
{
    [BsonIgnoreExtraElements]
    public class Location
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; } = null!;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public string? Address { get; set; }
        public string? City {  get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public List<string> Images { get; set; }
        public bool IsAvailable { get; set; }
        public string? OpenTime { get; set; }
        public string? DetailUrl { get; set; }
        public string? Hotline { get; set; }
        public string Price { get; set; }
        public Rating Rating { get; set; }
        public Rating WebsiteRating { get; set; }
        public float WebsiteRatingOverall { get; set; }
        public bool IsTrend {  get; set; }
        public bool IsTopYear { get; set; }
        public string CategoryId { get; set; }
    }
}
