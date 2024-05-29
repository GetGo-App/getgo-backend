using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetGo.Domain.Payload.Request.Status
{
    public class CreateStatusRequest
    {
        public string Content { get; set; }
        public List<string> Images { get; set; }
        public string Uploader { get; set; }
        public string PrivacyMode { get; set; }
    }
}
