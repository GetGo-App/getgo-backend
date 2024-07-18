using GetGo.Domain.Payload.Response.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetGo.Domain.Payload.Response.Messages
{
    public class LocationSuggestionMessageResponse
    {
        public string? texts_message {  get; set; }
        public LocationMessage? locations_message { get; set; }
    }
}
