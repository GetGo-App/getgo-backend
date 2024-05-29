using GetGo.Domain.Models;
using GetGo.Domain.Payload.Response.Locations;

namespace GetGo_BE.Services.Interfaces
{
    public interface ILocationService
    {
        public Task<List<Location>> GetTourismLocationList();
        public Task<GetLocationInfoResponse> GetTourismLocationById(string id);
        public Task<List<Location>> GetTrendLocations();
        public Task<List<Location>> GetTopYearLocations();
        public Task<List<Comment>> GetComment(string id);
        public Task<List<Location>> SearchLocation(string searchValue);
    }
}
