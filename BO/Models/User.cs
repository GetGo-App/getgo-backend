using System;
using System.Collections.Generic;

namespace BO.Models
{
    public partial class User
    {
        public User()
        {
            Photos = new HashSet<Photo>();
        }

        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? FullName { get; set; }
        public bool? Gender { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? PictureUrl { get; set; }
        public string? Role { get; set; }

        public virtual ICollection<Photo> Photos { get; set; }
    }
}
