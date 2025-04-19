using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp1.Core.Entities
{
    public class CommunityMembership
    {
        public int Id { get; set; }

        public required string UserId { get; set; }
        public required  ApplicationUser User { get; set; }

        public required  int CommunityId { get; set; }
        public required  Community Community { get; set; }

        public DateTime JoinedAt { get; set; }
    }
}
