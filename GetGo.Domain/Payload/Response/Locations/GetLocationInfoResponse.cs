using GetGo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetGo.Domain.Payload.Response.Locations
{
    public class GetLocationInfoResponse
    {
        public Location Location { get; set; }
        public float Rating_1 { get; set; }
        public float Rating_2 { get; set;}
        public float Rating_3 { get; set;}
        public float Rating_4 { get; set;}
        public float Rating_5 { get; set;}
    }
}
