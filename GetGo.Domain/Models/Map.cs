using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetGo.Domain.Models
{
    public class Map
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;
        public string UserId { get; set; }
        public List<int> Locations { get; set; }

        public Map(string userId, List<int> locations)
        {
            Id = ObjectId.GenerateNewId().ToString();
            UserId = userId;
            Locations = locations;
        }
    }
}
