using GetGo.Domain.Models;
using GetGo.Domain.Payload.Request.Route;
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
    public class MapRepository : BaseRepository<MapRepository>, IMapRepository
    {
        private readonly IMongoCollection<Map> _map;    

        public MapRepository(IOptions<MongoDBSettings> setting) : base(setting)
        {
            _map = _database.GetCollection<Map>("Map");
        }

        public async Task<List<Map>> GetMapList()
        {
            return await _map.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<Map> GetMapById(string id)
        {
            return await _map.Find(r => r.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateMap(CreateMapRequest request)
        {
            Map route = new Map(request.UserId, request.Locations);
            await _map.InsertOneAsync(route);
        }

        public async Task<List<Map>> GetUserMap(string userId)
        {
            return await _map.Find(m => m.UserId == userId).ToListAsync();
        }
    }
}
