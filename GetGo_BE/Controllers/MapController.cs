using GetGo.Domain.Models;
using GetGo.Domain.Payload.Request.Route;
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
    public class MapController : BaseController<MapController>
    {
        private readonly IMapService _mapService;
        public MapController(ILogger<MapController> logger, IMapService mapService) : base(logger)
        {
            _mapService = mapService;
        }

        [HttpGet(ApiEndPointConstant.Map.MapsEndpoint)]
        [ProducesResponseType(typeof(List<Map>), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Get map list")]
        public async Task<IActionResult> GetMapList()
        {
            var result = await _mapService.GetMapList();
            return Ok(result);
        }

        [HttpGet(ApiEndPointConstant.Map.MapEndpoint)]
        [ProducesResponseType(typeof(Map), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Get map by id")]
        public async Task<IActionResult> GetMapById(string id)
        {
            var result = await _mapService.GetMapById(id);
            return Ok(result);
        }

        [HttpGet(ApiEndPointConstant.Map.UserMapsEndpoint)]
        [ProducesResponseType(typeof(List<Map>), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Get user's map")]
        public async Task<IActionResult> GetUserMap(string userId)
        {
            var result = await _mapService.GetUserMap(userId);
            return Ok(result);
        }

        [HttpPost(ApiEndPointConstant.Map.MapsEndpoint)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Create map")]
        public async Task<IActionResult> CreateMap(CreateMapRequest request)
        {
            await _mapService.CreateMap(request);
            return Ok("Action success");
        }
    }
}
