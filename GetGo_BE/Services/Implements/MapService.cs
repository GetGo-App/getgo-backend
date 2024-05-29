using AutoMapper;
using GetGo.Domain.Models;
using GetGo.Domain.Payload.Request.Route;
using GetGo.Repository.Interfaces;
using GetGo_BE.Services.Interfaces;

namespace GetGo_BE.Services.Implements
{
    public class MapService : BaseService<MapService>, IMapService
    {
        private readonly IMapRepository _mapRepository;
        public MapService(ILogger<MapService> logger, IMapper mapper, IHttpContextAccessor httpContextAccessor, IMapRepository mapRepository) : base(logger, mapper, httpContextAccessor)
        {
            _mapRepository = mapRepository;
        }

        public async Task CreateMap(CreateMapRequest request)
        {
            await _mapRepository.CreateMap(request);
        }

        public async Task<Map> GetMapById(string id)
        {
            return await _mapRepository.GetMapById(id);
        }

        public async Task<List<Map>> GetMapList()
        {
            return await _mapRepository.GetMapList();
        }

        public async Task<List<Map>> GetUserMap(string userId)
        {
            return await _mapRepository.GetUserMap(userId);
        }
    }
}
