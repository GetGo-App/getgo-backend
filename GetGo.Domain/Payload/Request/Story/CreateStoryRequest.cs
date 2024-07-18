using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetGo.Domain.Payload.Request.Story
{
    public class CreateStoryRequest
    {
        public string Creator {  get; set; }
        public string Content { get; set; }
        public string Caption { get; set; }
    }
}
