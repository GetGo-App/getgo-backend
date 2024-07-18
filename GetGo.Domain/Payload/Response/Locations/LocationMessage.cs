using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetGo.Domain.Payload.Response.Locations
{
    public class LocationMessage
    {
        public List<int>? locations {  get; set; }
        public string? message { get; set; }
    }
}
