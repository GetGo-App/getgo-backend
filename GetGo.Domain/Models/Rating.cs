using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GetGo.Domain.Models
{
    public class Rating
    {
        [JsonPropertyName("1")]
        public float star1 { get; set; }
        [JsonPropertyName("2")]
        public float star2 { get; set; }
        [JsonPropertyName("3")]
        public float star3 { get; set; }
        [JsonPropertyName("4")]
        public float star4 { get; set; }
        [JsonPropertyName("5")]
        public float star5 { get; set; }
    }
}
