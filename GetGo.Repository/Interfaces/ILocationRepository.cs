using GetGo.Domain.Models;
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
        public Task<Location> GetTourismLocationById(string id);
        public Task<List<Location>> GetTrendLocations();
        public Task<List<Location>> GetTopYearLocations();
        public Task<List<Location>> SearchLocation(string searchValue);
        public Task UpdateRating(string id, Rating rating);
    }
}
