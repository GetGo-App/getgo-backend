using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GetGo.Domain.Models.Documents
{
    public class Rating
    {
        [JsonPropertyName("1")]
        public double star1 { get; set; }
        [JsonPropertyName("2")]
        public double star2 { get; set; }
        [JsonPropertyName("3")]
        public double star3 { get; set; }
        [JsonPropertyName("4")]
        public double star4 { get; set; }
        [JsonPropertyName("5")]
        public double star5 { get; set; }
    }
}
