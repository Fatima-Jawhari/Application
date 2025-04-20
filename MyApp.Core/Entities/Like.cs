using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp1.Core.Entities
{
    public class Like
    {
        public int Id { get; set; }

        public required  Guid UserId { get; set; }
        public  ApplicationUser User { get; set; }

        public Guid PostId { get; set; }
        public   Post Post { get; set; }

        public DateTime LikedAt { get; set; }
    }
}
