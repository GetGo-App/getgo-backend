using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetGo.Domain.Models
{
    public class Location
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string? Address { get; set; }
        public string? City {  get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public List<string> Images { get; set; }
        public bool IsAvailable { get; set; }
        public string Opentime { get; set; }
        public string DetailURL { get; set; }
        public string HotLine { get; set; }
        public string Price { get; set; }
        public Rating Rating { get; set; }
        public Rating WebSiteRating { get; set; }
        public float WebsiteRatingOverall { get; set; }
        public bool IsTrend {  get; set; }
        public bool IsTopYear { get; set; }
        public string CategoryId { get; set; }
    }
}
