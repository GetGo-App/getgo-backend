using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.DTOs.Response.Photo
{
    public class GetPhotoResponseDTO
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Tag { get; set; }
        public string? PhotoUrl { get; set; }
        public int? Uploader { get; set; }
        public DateTime? UploadedTime { get; set; }
    }
}
