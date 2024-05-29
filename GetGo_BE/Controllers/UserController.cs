using GetGo.Domain.Models;
using GetGo.Domain.Payload.Request.User;
using GetGo_BE.Constants;
using GetGo_BE.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GetGo_BE.Controllers
{
    [ApiController]
    public class UserController : BaseController<UserController>
    {
        private readonly IUserService _userService;
        
        public UserController(ILogger<UserController> logger, IUserService userService) : base(logger)
        {
            _userService = userService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet(ApiEndPointConstant.User.UsersEndpoint)]
        [ProducesResponseType(typeof(List<User>), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Get user list")]
        public async Task<IActionResult> GetUsersList()
        {
            var result = await _userService.GetUserList();
            return Ok(result);
        }

        [Authorize]
        [HttpGet(ApiEndPointConstant.User.UserEndpoint)]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Get user info by id")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var result = await _userService.GetUserById(id);
            return Ok(result);
        }

        [Authorize]
        [HttpPatch(ApiEndPointConstant.User.UserEndpoint)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Update user information")]
        public async Task<IActionResult> UpdateUserInfo(string id, UpdateUserRequest request)
        {
            await _userService.UpdateUser(id, request);
            return Ok("Action success");
        }

        [Authorize]
        [HttpGet(ApiEndPointConstant.User.UserFavLocationEndpoint)]
        [ProducesResponseType(typeof(List<Location>), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Get user favourite locations")]
        public async Task<IActionResult> GetFavLocation(string id)
        {
            var result = await _userService.GetFavLocation(id);

            return Ok(result);
        }

        [Authorize]
        [HttpGet(ApiEndPointConstant.User.UserFriendImagesEndpoint)]
        [ProducesResponseType(typeof(List<Image>), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Get user friends' images")]
        public async Task<IActionResult> GetFriendImages(string id)
        {
            var result = await _userService.GetFriendImage(id);

            return Ok(result);
        }

        [Authorize]
        [HttpGet(ApiEndPointConstant.User.UserFriendStatusesEndpoint)]
        [ProducesResponseType(typeof(List<Status>), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Get user friends' status")]
        public async Task<IActionResult> GetFriendStatus(string id)
        {
            var result = await _userService.GetFriendStatus(id);

            return Ok(result);
        }

        [HttpPost(ApiEndPointConstant.User.UserForgetPassEndpoint)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public async Task<IActionResult> SendOtpCode(string emailOrPhoneNumber)
        {
            await _userService.SendOtpCode(emailOrPhoneNumber);
            return Ok("Send success");
        }

        [HttpPatch(ApiEndPointConstant.User.UserForgetPassEndpoint)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public async Task<IActionResult> ResetPassword(string newPassword, string otpCode)
        {
            await _userService.ResetPassword(newPassword, otpCode);
            return Ok("Action success");
        }
    }
}
