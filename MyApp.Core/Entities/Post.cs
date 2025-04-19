using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp1.Core.Entities
{
    public class Post
    {
        public int PostID { get; set; }
        public  required string UserID { get; set; } // FK to ApplicationUser
        public required  string Content { get; set; }
        public string? ImageURL { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation
        public required ApplicationUser User { get; set; }
        public required  ICollection<Comment> Comments { get; set; }
        public required ICollection<Like> Likes { get; set; }

        public required  ICollection<Hashtag> Hashtags { get; set; }
    }
}
