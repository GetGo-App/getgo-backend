using GetGo.Domain.Models;
using GetGo.Domain.Payload.Request.Photo;
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
    public class ImageRepository : BaseRepository<ImageRepository>, IImageRepository
    {
        private readonly IMongoCollection<Image> _photos;

        public ImageRepository(IOptions<MongoDBSettings> setting) : base(setting)
        {
            _photos = _database.GetCollection<Image>("Image");
        }

        public async Task<List<Image>> GetPhotoList()
        {
            return await _photos.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<Image> GetPhotoById(string id)
        {
            return await _photos.Find(p => p.Id == id).SingleOrDefaultAsync();
        }

        public async Task AddPhoto(AddPhotoRequest request)
        {
            Image image = new Image(request.PhotoUrl, request.Uploader, request.PrivacyMode);

            await _photos.InsertOneAsync(image);
        }

        public async Task<Image> GetUserImage(string userId)
        {
            return await _photos.Find(p => p.Uploader == userId).SingleOrDefaultAsync();
        }
    }
}
