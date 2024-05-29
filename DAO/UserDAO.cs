using BO.DTOs.Response.Authentication;
using BO.Models;
using DAO.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class UserDAO
    {
        private static GetGoTestDBContext _dbContext;

        private static UserDAO instance;
        public static UserDAO Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new UserDAO();
                }
                return instance;
            }
        }

        public UserDAO()
        {
            if(_dbContext == null)
            {
                _dbContext = new GetGoTestDBContext();
            }
        }

        //User method
        public async Task<List<User>> GetAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        //Login method
        public async Task<LoginResponseDTO> Login(string email, string password)
        {
            User user = await _dbContext.Users.FirstOrDefaultAsync(u =>
                                                    u.Email.Equals(email) &&
                                                    u.Password.Equals(password));

            if (user == null) throw new BadHttpRequestException("Invalid username or password");

            LoginResponseDTO response = new LoginResponseDTO(user.Email, user.UserName, user.Password, user.PictureUrl);

            response.AccessToken = JwtAuthenticationUtil.GenerateJwtToken(user);
            return response;
        }

        public async Task<LoginResponseDTO> SignUp(string email, string password)
        {
            User user = await _dbContext.Users.FirstOrDefaultAsync(u =>
                                                    u.Email.Equals(email) &&
                                                    u.Password.Equals(password));

            if (user != null) throw new BadHttpRequestException("Email has already used");

            await _dbContext.Users.AddAsync(new User {Email = email, Password = password, UserName = email });

            LoginResponseDTO response = new LoginResponseDTO(user.Email, user.UserName, user.Password, user.PictureUrl);

            response.AccessToken = JwtAuthenticationUtil.GenerateJwtToken(user);
            return response;
        }
    }
}
