using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetGo.Domain.Payload.Request.Message
{
    public class AIChatRequest
    {
        public string question {  get; set; }
        public List<HistoryRequest>? history { get; set; }

        public AIChatRequest(string question, List<HistoryRequest>? history)
        {
            this.question = question;
            this.history = history;
        }

        public AIChatRequest(string question)
        {
            this.question = question;
            this.history = new List<HistoryRequest>();
        }

        public AIChatRequest(List<HistoryRequest>? history)
        {
            this.question = String.Empty;
            this.history = history;
        }

        public AIChatRequest()
        {
            this.history = new List<HistoryRequest>();
        }
    }
}
