using GetGo.Domain.Models;
using GetGo.Domain.Payload.Response.Locations;
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
    public class LocationController : BaseController<LocationController>
    {
        private readonly ILocationService _locationService;

        public LocationController(ILogger<LocationController> logger, ILocationService locationService) : base(logger)
        {
            _locationService = locationService;
        }

        [HttpGet(ApiEndPointConstant.Locations.LocationsEndpoint)]
        [ProducesResponseType(typeof(List<Location>), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Get location list")]
        public async Task<IActionResult> GetLocationList()
        {
            var result = await _locationService.GetTourismLocationList();
            return Ok(result);
        }

        [HttpGet(ApiEndPointConstant.Locations.LocationEndpoint)]
        [ProducesResponseType(typeof(Location), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Get location by id")]
        public async Task<IActionResult> GetLocationById(string id)
        {
            var result = await _locationService.GetTourismLocationById(id);
            return Ok(result);
        }

        [HttpGet(ApiEndPointConstant.Locations.TrendLocationEndpoint)]
        [ProducesResponseType(typeof(List<Location>), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Get trend location list")]
        public async Task<IActionResult> GetTrendLocation()
        {
            var result = await _locationService.GetTrendLocations();
            return Ok(result);
        }

        [HttpGet(ApiEndPointConstant.Locations.TopYearLocationEndpoint)]
        [ProducesResponseType(typeof(List<Location>), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Get top-year location list")]
        public async Task<IActionResult> GetTopYearLocation()
        {
            var result = await _locationService.GetTopYearLocations();
            return Ok(result);
        }

        [HttpGet(ApiEndPointConstant.Locations.LocationCommentEndpoint)]
        [ProducesResponseType(typeof(List<Comment>), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Get comment list in location")]
        public async Task<IActionResult> GetLocationComments(string id)
        {
            var result = await _locationService.GetComment(id);
            return Ok(result);
        }

        [HttpGet(ApiEndPointConstant.Locations.SearchLocationsEndpoint)]
        [ProducesResponseType(typeof(List<Location>), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Search for locations")]
        public async Task<IActionResult> SearchLocation(string searchValue)
        {
            var result = await _locationService.SearchLocation(searchValue);
            return Ok(result);
        }

        [HttpPut(ApiEndPointConstant.Locations.LocationsRatingEndpoint)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [SwaggerOperation(Summary = "Update the rating of all locations")]
        public async Task<IActionResult> UpdateLocationRatings()
        {
            await _locationService.UpdateRatings();
            return Ok("Action success");
        }
    }
}
