using GetGo.Domain.Models;
using GetGo.Domain.Models.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetGo.Repository.Interfaces
{
    public interface ILocationRepository
    {
        public Task<List<Location>> GetTourismLocationList();
        public Task<Location> GetTourismLocationById(int id);
        public Task<List<Location>> GetTrendLocations();
        public Task<List<Location>> GetTopYearLocations();
        public Task<List<Location>> SearchLocation(string searchValue);
        public Task UpdateRating(int id, Rating rating);

        public Task<List<Location>> GetCityLocation(string city);
        public Task<string> GetLocationName(List<int> id);
    }
}
