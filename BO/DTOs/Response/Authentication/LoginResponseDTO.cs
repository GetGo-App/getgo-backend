using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.DTOs.Response.Authentication
{
    public class LoginResponseDTO
    {
        public string AccessToken { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        public string PictureUrl { get; set; }

        public LoginResponseDTO(string email, string username, string role, string pictureUrl)
        {
            Email = email;
            UserName = username;
            Role = role;
            PictureUrl = pictureUrl;
        }
    }
}
