using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetGo.Domain.Payload.Request.Feedback
{
    public class CreateFeedbackRequest
    {
        public string Content { get; set; }
        public string UserId { get; set; }
    }
}
