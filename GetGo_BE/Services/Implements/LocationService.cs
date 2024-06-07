using AutoMapper;
using GetGo.Domain.Models;
using GetGo.Domain.Payload.Response.Locations;
using GetGo.Repository.Interfaces;
using GetGo_BE.Services.Interfaces;
using Org.BouncyCastle.Pkcs;
using static GetGo_BE.Constants.ApiEndPointConstant;

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

        public async Task<Location> GetTourismLocationById(string id)
        {
            //List<Comment> comments = await _commentRepository.GetLocationComment(id);
            Location location = await _tourismLocationRepository.GetTourismLocationById(id);

            return location;
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

        public async Task UpdateRatings()
        {
            var locations = await _tourismLocationRepository.GetTourismLocationList();
            foreach(Location place in locations)
            {
                var comments = await _commentRepository.GetLocationComment(place.Id);
                Rating rating = new Rating()
                {
                    star1 = comments.Where(x => x.Rating == 1).Sum(x => x.Rating) / comments.Where(x => x.Rating == 1).Count(),
                    star2 = comments.Where(x => x.Rating == 2).Sum(x => x.Rating) / comments.Where(x => x.Rating == 2).Count(),
                    star3 = comments.Where(x => x.Rating == 3).Sum(x => x.Rating) / comments.Where(x => x.Rating == 3).Count(),
                    star4 = comments.Where(x => x.Rating == 4).Sum(x => x.Rating) / comments.Where(x => x.Rating == 4).Count(),
                    star5 = comments.Where(x => x.Rating == 5).Sum(x => x.Rating) / comments.Where(x => x.Rating == 5).Count(),
                };

                await _tourismLocationRepository.UpdateRating(place.Id, rating);
            }
        }
    }
}
