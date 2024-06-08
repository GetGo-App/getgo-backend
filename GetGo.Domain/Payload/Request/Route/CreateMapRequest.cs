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
        public List<int> Locations { get; set; }

        public CreateMapRequest(string userId, List<int> locations)
        {
            UserId = userId;
            Locations = locations;
        }
    }
}
