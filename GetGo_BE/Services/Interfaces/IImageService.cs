using GetGo.Domain.Models;
using GetGo.Domain.Payload.Request.Photo;

namespace GetGo_BE.Services.Interfaces
{
    public interface IImageService
    {
        public Task<List<Image>> GetPhotoList();
        public Task<Image> GetPhotoById(string id);
        public Task AddPhoto(AddPhotoRequest request);
        public Task<Image> GetUserImage(string userId);
    }
}
