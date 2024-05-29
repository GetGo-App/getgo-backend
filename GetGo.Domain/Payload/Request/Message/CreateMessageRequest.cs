using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetGo.Domain.Payload.Request.Message
{
    public class CreateMessageRequest
    {
        public string User1 { get; set; }
        public string User2 { get; set; }
        public DateTime Timestamp { get; set; }
        public string Content { get; set; }
    }
}
