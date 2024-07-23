using GetGo.Domain.Payload.Response.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetGo.Domain.Payload.Request.Message
{
    public class AIHistoryRequest
    {
        public string? question { get; set; }
        public string? answer { get; set; }

        public AIHistoryRequest(string? question, string? answer)
        {
            this.question = question;
            this.answer = answer;
        }
    }
}
