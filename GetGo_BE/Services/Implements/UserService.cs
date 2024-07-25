using AutoMapper;
using GetGo.Domain.Models;
using GetGo.Domain.Paginate;
using GetGo.Domain.Payload.Request.User;
using GetGo.Domain.Payload.Response.User;
using GetGo.Repository.Interfaces;
using GetGo_BE.Enums.Image;
using GetGo_BE.Services.Interfaces;
using MailKit.Net.Smtp;
using MimeKit;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace GetGo_BE.Services.Implements
{
    public class UserService : BaseService<UserService>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILocationRepository _locationRepository;
        private readonly IImageRepository _imageRepository;
        private readonly IStatusRepository _statusRepository;

        public UserService(ILogger<UserService> logger, IMapper mapper, IHttpContextAccessor httpContextAccessor,
            IUserRepository userRepository, ILocationRepository locationRepository, IImageRepository imageRepository, IStatusRepository statusRepository)
            : base(logger, mapper, httpContextAccessor)
        {
            _userRepository = userRepository;
            _locationRepository = locationRepository;
            _imageRepository = imageRepository;
            _statusRepository = statusRepository;
        }

        public async Task DeleteUser(string id)
        {
            await _userRepository.DeleteUser(id);
        }

        public async Task<User> GetUserById(string id)
        {
            return await _userRepository.GetUserById(id);
        }

        public async Task<User> GetUserByUsername(string username)
        {
            return await _userRepository.GetUserByUsername(username);
        }

        public async Task<List<User>> GetUserList()
        {
            return await _userRepository.GetUserList();
        }

        public async Task<AuthenticationResponse> SignIn(SignInRequest request)
        {
            return await _userRepository.SignIn(request);
        }

        public async Task<List<User>> GetUserFriends(string id)
        {
            return await _userRepository.GetUserFriends(id);
        }

        public async Task<AuthenticationResponse> SignUp(SignUpRequest request)
        {
            return await _userRepository.SignUp(request);
        }

        public async Task<AuthenticationResponse> GoogleAuthentication(GoogleAuthRequest request)
        {
            return await _userRepository.GoogleAuthentication(request);
        }

        public async Task UpdateUser(string username, UpdateUserRequest request)
        {
            await _userRepository.UpdateUser(username, request);
        }

        public async Task<string> GetUserSubscription(string id)
        {
            return await _userRepository.GetUserSubscription(id);
        }

        public async Task<List<Location>> GetFavLocation(string username)
        {
            User user = await _userRepository.GetUserByUsername(username);

            List<Location> favLocations = new List<Location>();

            if (user.Favourites == null) return null;

            foreach (int locationId in user.Favourites)
            {
                favLocations.Add(await _locationRepository.GetTourismLocationById(locationId));
            }

            return favLocations;
        }

        public async Task<List<Image>> GetFriendImage(string username)
        {
            User user = await _userRepository.GetUserByUsername(username);

            List<Image> friendsImage = new List<Image>();

            if (user.Friends == null) return null;

            foreach (string friend in user.Friends)
            {
                Image image = await _imageRepository.GetUserImage(friend);
                if (!image.PrivacyMode.Equals(ImagePrivacyEnum.MySelf.ToString()))
                {
                    friendsImage.Add(image);
                }
            }

            return friendsImage;
        }

        public async Task<List<Status>> GetFriendStatus(string username)
        {
            User user = await _userRepository.GetUserByUsername(username);

            List<Status> friendsStatus = new List<Status>();

            if (user.Friends == null) return null;

            foreach (string friend in user.Friends)
            {
                List<Status> status = await _statusRepository.GetFriendStatus(friend);
                friendsStatus.AddRange(status);
            }

            return friendsStatus;
        }

        public async Task ChangeUserPack(string id, string packName)
        {
            await _userRepository.ChangeUserPack(id, packName);
        }

        #region ResetPassword
        public async Task ResetPassword(string newPass, string otpcode)
        {
            if (String.IsNullOrEmpty(newPass)) throw new BadHttpRequestException("Password cannot empty");
            await _userRepository.ResetPass(newPass, otpcode);
        }

        public async Task SendOtpCode(string emailOrPhone)
        {
            Random random = new Random();
            string otpCode = random.Next(100000, 999999).ToString();

            string result = await _userRepository.ValidateAndUpdateOtpCode(emailOrPhone, otpCode);

            switch (result)
            {
                case "Email":
                    SendOtpCodeToEmail(emailOrPhone, otpCode);
                    break;
                case "Phone":
                    SendOtpCodeToPhone(emailOrPhone, otpCode);
                    break;
                default:
                    throw new BadHttpRequestException("Cannot find email or phone number");
            }
        }

        private async Task SendOtpCodeToEmail(string email, string otpCode)
        {
            var emailToSend = new MimeMessage();
            emailToSend.From.Add(MailboxAddress.Parse("appsp377@gmail.com"));
            emailToSend.To.Add(MailboxAddress.Parse(email));
            emailToSend.Subject = "Reset Password Code";
            emailToSend.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = $"Your OTP Code is {otpCode}" };

            using(var emailClient = new MailKit.Net.Smtp.SmtpClient())
            {
                emailClient.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                emailClient.Authenticate("appsp377@gmail.com", "mpac zjfb iyax bgpd");
                await emailClient.SendAsync(emailToSend);
                emailClient.Disconnect(true);
            }
        }

        private async Task SendOtpCodeToPhone(string phoneNumber, string otpCode)
        {
            string apiKey = "NTg2MjMyNTM1OTU3MzU1NzcxNWE0MjQ3MzAzMjMwNjU";
            string sender = "Supporter";
            string message = $"Your OTP Code: {otpCode}";
            string result = "";

            String url = "https://api.txtlocal.com/send/?apikey=" + apiKey + "&numbers=" + phoneNumber + "&message=" + message + "&sender=" + sender;
            //refer to parameters to complete correct url string

            StreamWriter myWriter = null;
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url);

            objRequest.Method = "POST";
            objRequest.ContentLength = Encoding.UTF8.GetByteCount(url);
            objRequest.ContentType = "application/x-www-form-urlencoded";
            try
            {
                myWriter = new StreamWriter(objRequest.GetRequestStream());
                myWriter.Write(url);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                myWriter.Close();
            }

            HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
            using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
            {
                result = sr.ReadToEnd();
                // Close and clean up the StreamReader
                sr.Close();
            }
        }
        #endregion
    }
}
