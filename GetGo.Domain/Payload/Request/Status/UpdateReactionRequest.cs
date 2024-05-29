using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetGo.Domain.Payload.Request.Status
{
    public class UpdateReactionRequest
    {
        public string ReactedUserId { get; set; }
        public bool IsReacted { get; set; }
    }
}
