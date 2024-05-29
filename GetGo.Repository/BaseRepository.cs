using GetGo.Domain.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetGo.Repository
{
    public abstract class BaseRepository<T> where T : class
    {
        protected MongoClient _client;
        protected IMongoDatabase _database;

        public BaseRepository(IOptions<MongoDBSettings> setting)
        {
            _client = new MongoClient(setting.Value.ConnectionURI);
            _database = _client.GetDatabase(setting.Value.DatabaseName);
        }
    }
}
