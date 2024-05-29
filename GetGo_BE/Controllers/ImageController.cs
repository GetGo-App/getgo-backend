using GetGo.Domain.Models;
using GetGo.Domain.Payload.Request.Photo;
using GetGo_BE.Constants;
using GetGo_BE.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GetGo_BE.Controllers
{
    [Authorize]
    [ApiController]
    public class ImageController : BaseController<ImageController>
    {
        private readonly IImageService _imageService;
        public ImageController(ILogger<ImageController> logger, IImageService imageService) : base(logger)
        {
            _imageService = imageService;
        }

        [HttpGet(ApiEndPointConstant.Image.ImagesEndpoint)]
        [ProducesResponseType(typeof(List<Image>), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Get image list")]
        public async Task<IActionResult> GetImageList()
        {
            var result = await _imageService.GetPhotoList();
            return Ok(result);
        }

        [HttpGet(ApiEndPointConstant.Image.ImageEndpoint)]
        [ProducesResponseType(typeof(Image), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Get image by id")]
        public async Task<IActionResult> GetImageByIs(string id)
        {
            var result = await _imageService.GetPhotoById(id);
            return Ok(result);
        }

        [HttpPost(ApiEndPointConstant.Image.ImagesEndpoint)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Create image")]
        public async Task<IActionResult> CreateImage(AddPhotoRequest request)
        {
            await _imageService.AddPhoto(request);
            return Ok("Action success");
        }

        [HttpGet(ApiEndPointConstant.Image.UserImageEndpoint)]
        [ProducesResponseType(typeof(List<Image>), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Get user's image")]
        public async Task<IActionResult> GetUserImage(string userId)
        {
            var result = await _imageService.GetUserImage(userId);
            return Ok(result);
        }
    }
}
