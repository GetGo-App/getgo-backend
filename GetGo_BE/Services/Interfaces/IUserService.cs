using GetGo.Domain.Models;
using GetGo.Domain.Paginate;
using GetGo.Domain.Payload.Request.User;
using GetGo.Domain.Payload.Response.User;

namespace GetGo_BE.Services.Interfaces
{
    public interface IUserService
    {
        public Task<List<User>> GetUserList();
        public Task<User> GetUserById(string id);
        public Task<User> GetUserByUsername(string username);
        public Task ChangeUserPack(string id, string packName);
        public Task UpdateUser(string username, UpdateUserRequest request);
        public Task DeleteUser(string id);
        public Task<List<Location>> GetFavLocation(string username);
        public Task<List<Image>> GetFriendImage(string username);
        public Task<List<Status>> GetFriendStatus(string username);

        public Task SendOtpCode(string emailOrPhone);
        public Task ResetPassword(string newPass, string otpcode);

        public Task<AuthenticationResponse> SignIn(SignInRequest request);
        public Task<AuthenticationResponse> SignUp(SignUpRequest request);
    }
}
