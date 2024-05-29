using GetGo.Domain.Models;
using GetGo.Domain.Payload.Request.Route;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetGo.Repository.Interfaces
{
    public interface IMapRepository
    {
        public Task<List<Map>> GetMapList();
        public Task<Map> GetMapById(string id);
        public Task CreateMap(CreateMapRequest request);
        public Task<List<Map>> GetUserMap(string userId);
    }
}
