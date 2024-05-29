using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetGo.Domain.Payload.Response.User
{
    public class AuthenticationResponse
    {
        public string AccessToken { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }

        public AuthenticationResponse(string accessToken, string username, string email, bool isActive)
        {
            AccessToken = accessToken;
            Username = username;
            Email = email;
            IsActive = isActive;
        }
    }
}
