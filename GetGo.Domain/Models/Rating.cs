using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetGo.Domain.Models
{
    public class Rating
    {
        public float TotalRating { get; set; }
        public float WebRating { get; set; }
        public float UserRating { get; set; }
    }
}
