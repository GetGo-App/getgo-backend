using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetGo.Domain.Payload.Request.User
{
    public class GoogleAuthRequest
    {
        public string Email { get; set; }

        public GoogleAuthRequest(string email)
        {
            Email = email;
        }
    }
}
