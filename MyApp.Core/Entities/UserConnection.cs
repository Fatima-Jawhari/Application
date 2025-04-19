using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp1.Core.Entities
{
    public class UserConnection
    {
        public int Id { get; set; }

        public required string FollowerId { get; set; }
        public required ApplicationUser Follower { get; set; }

        public required string FolloweeId { get; set; }
        public required ApplicationUser Followee { get; set; }

        public DateTime ConnectedAt { get; set; } = DateTime.UtcNow;
    }

}
