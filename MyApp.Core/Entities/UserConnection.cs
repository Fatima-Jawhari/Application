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

        public required Guid FollowerId { get; set; }
        public ApplicationUser Follower { get; set; }

        public required Guid FollowedId { get; set; }
        public ApplicationUser Followed { get; set; }

        public DateTime ConnectedAt { get; set; } = DateTime.UtcNow;
    }

}
