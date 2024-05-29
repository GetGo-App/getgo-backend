using GetGo.Domain.Models;
using GetGo.Domain.Payload.Request.Photo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetGo.Repository.Interfaces
{
    public interface IImageRepository
    {
        public Task<List<Image>> GetPhotoList();
        public Task<Image> GetPhotoById(string id);
        public Task AddPhoto(AddPhotoRequest request);
        public Task<Image> GetUserImage(string userId);
    }
}
