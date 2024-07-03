using GetGo.Domain.Models;
using GetGo.Domain.Payload.Request.User;
using GetGo.Domain.Payload.Response.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetGo.Repository.Interfaces
{
    public interface IUserRepository
    {
        public Task<List<User>> GetUserList();
        public Task<User> GetUserById(string id);
        public Task<User> GetUserByUsername(string username);
        public Task UpdateUser(string username, UpdateUserRequest request);
        public Task ChangeUserPack(string id, string packName);
        public Task DeleteUser(string id);

        public Task<string> ValidateAndUpdateOtpCode(string emailOrPhone, string otpCode);
        public Task ResetPass(string password, string otpCode);

        public Task<AuthenticationResponse> SignIn(SignInRequest request);
        public Task<AuthenticationResponse> SignUp(SignUpRequest request);
    }
}
