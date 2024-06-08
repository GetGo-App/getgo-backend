using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetGo.Domain.Payload.Request.Comment
{
    public class CreateCommentRequest
    {
        public string Content { get; set; }
        public List<string> Images { get; set; }
        public float Rating { get; set; }
        public string UserId { get; set; }
        public int Location { get; set; }
    }
}
