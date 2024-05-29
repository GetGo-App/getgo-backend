using BO.DTOs.Response.Photo;
using BO.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class PhotoDAO
    {
        private static GetGoTestDBContext _dbContext;

        private static PhotoDAO instance;
        public static PhotoDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PhotoDAO();
                }
                return instance;
            }
        }

        public PhotoDAO()
        {
            if (_dbContext == null)
            {
                _dbContext = new GetGoTestDBContext();
            }
        }

        public async Task<List<GetPhotoResponseDTO>> GetPhotos()
        {
            return await _dbContext.Photos.Select(p => new GetPhotoResponseDTO
            {
                Id = p.Id,
                Title = p.Title,
                Tag = p.Tag,
                PhotoUrl = p.PhotoUrl,
                UploadedTime = p.UploadedTime,
                Uploader = p.Uploader,
            }).ToListAsync();   
        }
    }
}
