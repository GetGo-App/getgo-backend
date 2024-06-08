using GetGo.Domain.Models;
using GetGo.Domain.Models.Documents;
using GetGo.Repository.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetGo.Repository.Implements
{
    public class LocationRepository : BaseRepository<LocationRepository>, ILocationRepository
    {
        private readonly IMongoCollection<Location> _tourismLocations;

        public LocationRepository(IOptions<MongoDBSettings> setting) : base(setting)
        {
            _tourismLocations = _database.GetCollection<Location>("Location");
        }

        public async Task<List<Location>> GetTourismLocationList()
        {
            return await _tourismLocations.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<Location> GetTourismLocationById(int id)
        {
            return await _tourismLocations.Find(tl => tl.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Location>> GetTrendLocations()
        {
            return await _tourismLocations.Find(tl => tl.IsTrend).ToListAsync();
        }

        public async Task<List<Location>> GetTopYearLocations()
        {
            return await _tourismLocations.Find(tl => tl.IsTopYear).ToListAsync();
        }

        public async Task<List<Location>> SearchLocation(string searchValue)
        {
            return await _tourismLocations.Find(tl => tl.Name.Contains(searchValue) ||
                                                      tl.Address.Contains(searchValue)).ToListAsync();
        }

        public async Task UpdateRating(int id, Rating rating)
        {
            Location location = await _tourismLocations.Find(tl => tl.Id == id).FirstOrDefaultAsync();
            location.Rating = rating;
            await _tourismLocations.ReplaceOneAsync(tl => tl.Id == id, location);
        }
    }
}
