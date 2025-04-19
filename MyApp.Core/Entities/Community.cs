using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp1.Core.Entities
{
    public class Community
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }

        public DateTime CreatedAt { get; set; }
        public required  ICollection<CommunityMemberships> Members { get; set; }
    }
}
