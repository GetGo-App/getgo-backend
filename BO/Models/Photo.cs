using System;
using System.Collections.Generic;

namespace BO.Models
{
    public partial class Photo
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Tag { get; set; }
        public string? PhotoUrl { get; set; }
        public int? Uploader { get; set; }
        public DateTime? UploadedTime { get; set; }

        public virtual User? UploaderNavigation { get; set; }
    }
}
