using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetGo.Domain.Payload.Request.Photo
{
    public class AddPhotoRequest
    {
        public string? Title { get; set; }
        public string? PhotoUrl { get; set; }
        public string? Uploader { get; set; }
        public string PrivacyMode { get; set; }
    }
}
