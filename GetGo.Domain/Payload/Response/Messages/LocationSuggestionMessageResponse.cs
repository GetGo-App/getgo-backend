using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetGo.Domain.Payload.Response.Messages
{
    public class LocationSuggestionMessageResponse
    {
        public List<int>? ids_location {  get; set; }
        public string? text {  get; set; }
    }
}
