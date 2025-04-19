using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp1.Core.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public required string Content { get; set; }
        public DateTime CreatedAt { get; set; }

        public int PostId { get; set; }
        public required Post Post { get; set; }

        public required string UserId { get; set; }
        public required ApplicationUser User { get; set; }
    }
}
