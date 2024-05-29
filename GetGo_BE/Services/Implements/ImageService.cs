using AutoMapper;
using GetGo.Domain.Models;
using GetGo.Domain.Payload.Request.Photo;
using GetGo.Repository.Interfaces;
using GetGo_BE.Services.Interfaces;

namespace GetGo_BE.Services.Implements
{
    public class ImageService : BaseService<ImageService>, IImageService
    {
        private readonly IImageRepository _photoRepository;

        public ImageService(ILogger<ImageService> logger, IMapper mapper, IHttpContextAccessor httpContextAccessor, IImageRepository photoRepository) : base(logger, mapper, httpContextAccessor)
        {
            _photoRepository = photoRepository;
        }

        public async Task AddPhoto(AddPhotoRequest request)
        {
           await _photoRepository.AddPhoto(request);
        }

        public async Task<Image> GetPhotoById(string id)
        {
            return await _photoRepository.GetPhotoById(id);
        }

        public async Task<List<Image>> GetPhotoList()
        {
            return await _photoRepository.GetPhotoList();
        }

        public async Task<Image> GetUserImage(string userId)
        {
            return await _photoRepository.GetUserImage(userId);
        }
    }
}
