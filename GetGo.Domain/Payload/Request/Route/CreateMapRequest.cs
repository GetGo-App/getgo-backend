using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetGo.Domain.Payload.Request.Route
{
    public class CreateMapRequest
    {
        public string UserId { get; set; }
        public List<string> Locations { get; set; }
    }
}
