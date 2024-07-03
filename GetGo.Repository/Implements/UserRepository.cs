using GetGo.Domain.Enums.User;
using GetGo.Domain.Models;
using GetGo.Domain.Payload.Request.User;
using GetGo.Domain.Payload.Response.User;
using GetGo.Repository.Interfaces;
using GetGo.Repository.Utils;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace GetGo.Repository.Implements
{
    public class UserRepository : BaseRepository<UserRepository>, IUserRepository
    {
        private readonly IMongoCollection<User> _users;

        public UserRepository(IOptions<MongoDBSettings> setting) : base(setting)
        {
            _users = _database.GetCollection<User>("User");
        }

        #region Basic CRUD
        public async Task<List<User>> GetUserList()
        {
            return await _users.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<User> GetUserById(string id)
        {
            return await _users.Find(u => u.Id == id).FirstOrDefaultAsync();
        }

        public async Task<User> GetUserByUsername(string username)
        {
            return await _users.Find(u => u.UserName.Equals(username)).FirstOrDefaultAsync();
        }

        public async Task UpdateUser(string username, UpdateUserRequest request)
        {
            User user = await _users.Find(u => u.UserName.Equals(username)).FirstOrDefaultAsync();

            //Change data
            user.UserName = String.IsNullOrEmpty(request.UserName) ? user.UserName : request.UserName;
            user.Password = String.IsNullOrEmpty(request.Password) ? user.Password : request.Password;
            user.Gender = request.Gender == null ? user.Gender : request.Gender;
            user.Email = String.IsNullOrEmpty(request.Email) ? user.Email : request.Email;
            user.PhoneNumber = String.IsNullOrEmpty(request.PhoneNumber) ? user.PhoneNumber : request.PhoneNumber;
            user.Avatar = String.IsNullOrEmpty(request.Avatar) ? user.Avatar : request.Avatar;
            user.Birthday = request.Birthday;

            await _users.ReplaceOneAsync(u => u.UserName.Equals(username), user);
        }

        public async Task ChangeUserPack(string id, string packName)
        {
            User user = await _users.Find(u => u.Id.Equals(id)).FirstOrDefaultAsync();

            //Change data
            switch (packName)
            {
                case "Premium":
                    user.Subscription = SubcriptionEnum.Premium.ToString(); break;
                case "None":
                    user.Subscription = SubcriptionEnum.None.ToString(); break;
                default: throw new Exception($"There is no pack name {packName}");
            }

            await _users.ReplaceOneAsync(u => u.Id.Equals(id), user);
        }

        public async Task DeleteUser(string id)
        {
            FilterDefinition<User> filterDefinition = Builders<User>.Filter.Eq("Id", id);
            await _users.DeleteOneAsync(filterDefinition);
            return;
        }
        #endregion

        #region Authentication
        public async Task<AuthenticationResponse> SignIn(SignInRequest request)
        {
            User user = await _users.Find(u => u.Email.Equals(request.Email)).FirstOrDefaultAsync();
            if (user == null) return null;

            var token = JwtUtil.GenerateJwtToken(user);
            return new AuthenticationResponse(token, user.UserName, user.Email, user.IsActive);
        }

        public async Task<AuthenticationResponse> SignUp(SignUpRequest request)
        {
            User user = await _users.Find(u => u.Email.Equals(request.Email) || u.UserName.Equals(request.UserName)).FirstOrDefaultAsync();
            if (user != null) return null;

            User newUser = new User
            (
                ObjectId.GenerateNewId().ToString(),
                request.UserName,
                request.Password,
                request.Email
            );

            await _users.InsertOneAsync(newUser);

            var token = JwtUtil.GenerateJwtToken(newUser);
            return new AuthenticationResponse(token, newUser.UserName, newUser.Email, newUser.IsActive);
        }

        #endregion

        #region Otp forget code Method
        public async Task<string> ValidateAndUpdateOtpCode(string emailOrPhone, string otpCode)
        {
            bool isEmail = true;

            User user = await _users.Find(u => u.Email.Equals(emailOrPhone)).FirstOrDefaultAsync();
            if(user == null)
            {
                user = await _users.Find(u => u.PhoneNumber.Equals(emailOrPhone)).FirstOrDefaultAsync();
                isEmail = false;
            }

            if (user == null) return null;

            user.ForgetPassCode =  otpCode;
            await _users.ReplaceOneAsync(u => u.Id == user.Id, user);

            if (isEmail) return "Email";
            else return "Phone";
        }

        public async Task ResetPass(string password, string otpCode)
        {
            User user = await _users.Find(u => u.ForgetPassCode.Equals(otpCode)).FirstOrDefaultAsync();
            if (user == null) return;

            user.Password = password;
            user.ForgetPassCode = String.Empty;

            await _users.ReplaceOneAsync(u => u.Id == user.Id, user);
        }
        #endregion
    }
}
