using GetGo.Domain.Models;
using GetGo.Domain.Payload.Request.Route;

namespace GetGo_BE.Services.Interfaces
{
    public interface IMapService
    {
        public Task<List<Map>> GetMapList();
        public Task<Map> GetMapById(string id);
        public Task CreateMap(CreateMapRequest request);
        public Task<List<Map>> GetUserMap(string userId);
    }
}
