using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace GetGo.Domain.Models
{
    public partial class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Gender { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime Birthday { get; set; }
        public string? Avatar { get; set; }
        public string? Role { get; set; }
        public bool IsActive { get; set; }
        public List<string> Friends { get; set; }
        public List<int> Favourites { get; set; }
        public string? ForgetPassCode { get; set; }

        public User(string id, string? userName, string? password, string? email)
        {
            Id = id;
            UserName = userName;
            Password = password;
            Email = email;
            IsActive = true;
            Role = "Customer";
        }
    }
}
