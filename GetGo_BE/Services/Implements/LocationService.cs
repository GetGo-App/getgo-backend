using AutoMapper;
using GetGo.Domain.Models;
using GetGo.Domain.Payload.Response.Locations;
using GetGo.Repository.Interfaces;
using GetGo_BE.Services.Interfaces;

namespace GetGo_BE.Services.Implements
{
    public class LocationService : BaseService<LocationService>, ILocationService
    {
        private readonly ILocationRepository _tourismLocationRepository;
        private readonly ICommentRepository _commentRepository;

        public LocationService(ILogger<LocationService> logger, IMapper mapper, IHttpContextAccessor httpContextAccessor,
            ILocationRepository tourismLocationRepository, ICommentRepository commentRepository) : base(logger, mapper, httpContextAccessor)
        {
            _tourismLocationRepository = tourismLocationRepository;
            _commentRepository = commentRepository;
        }

        public async Task<List<Location>> GetTopYearLocations()
        {
            return await _tourismLocationRepository.GetTopYearLocations();
        }

        public async Task<GetLocationInfoResponse> GetTourismLocationById(string id)
        {
            List<Comment> comments = await _commentRepository.GetLocationComment(id);
            Location location = await _tourismLocationRepository.GetTourismLocationById(id);

            return new GetLocationInfoResponse()
            {
                Location = location,
                Rating_1 = comments.Count(c => c.Rating == 1),
                Rating_2 = comments.Count(c => c.Rating == 2),
                Rating_3 = comments.Count(c => c.Rating == 3),
                Rating_4 = comments.Count(c => c.Rating == 4),
                Rating_5 = comments.Count(c => c.Rating == 5),
            };
        }

        public async Task<List<Location>> GetTourismLocationList()
        {
            return await _tourismLocationRepository.GetTourismLocationList();
        }

        public async Task<List<Location>> GetTrendLocations()
        {
            return await _tourismLocationRepository.GetTrendLocations();
        }

        public async Task<List<Comment>> GetComment(string id)
        {
            return await _commentRepository.GetLocationComment(id);
        }

        public async Task<List<Location>> SearchLocation(string searchValue)
        {
            return await _tourismLocationRepository.SearchLocation(searchValue);
        }
    }
}
