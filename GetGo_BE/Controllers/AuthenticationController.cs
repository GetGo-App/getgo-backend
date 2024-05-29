using GetGo.Domain.Paginate;
using GetGo.Domain.Payload.Request.User;
using GetGo.Domain.Payload.Response;
using GetGo.Domain.Payload.Response.User;
using GetGo_BE.Constants;
using GetGo_BE.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GetGo_BE.Controllers
{
    [ApiController]
    public class AuthenticationController : BaseController<AuthenticationController>
    {
        private readonly IUserService _userService;

        public AuthenticationController(ILogger<AuthenticationController> logger, IUserService userService) : base(logger)
        {
            _userService = userService;
        }

        [HttpPost(ApiEndPointConstant.Authentication.SignInEndpoint)]
        [ProducesResponseType(typeof(AuthenticationResponse), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(UnauthorizedObjectResult))]
        public async Task<IActionResult> SignIn(SignInRequest request)
        {
            var result = await _userService.SignIn(request);
            if(result == null)
            {
                return Unauthorized(new ErrorResponse()
                {
                    StatusCode = StatusCodes.Status401Unauthorized,
                    Error = MessageConstant.Authentication.InvalidEmailOrPassword,
                    TimeStamp = DateTime.Now
                });
            }
            return Ok(result);
        }

        [HttpPost(ApiEndPointConstant.Authentication.SignUpEndpoint)]
        [ProducesResponseType(typeof(AuthenticationResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> SignUn(SignUpRequest request)
        {
            var result = await _userService.SignUp(request);
            if (result == null)
            {
                return BadRequest(new ErrorResponse()
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Error = MessageConstant.Authentication.AlreadyUsedEmail,
                    TimeStamp = DateTime.Now
                });
            }
            return Ok(result);
        }
    }
}
