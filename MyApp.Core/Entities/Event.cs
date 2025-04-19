using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp1.Core.Entities
{
    public class Event
    {
        public int Id { get; set; }
        public required  string Title { get; set; }
        public required string Description { get; set; }
        public DateTime EventDate { get; set; }

        public int CommunityId { get; set; }
        public required Community Community { get; set; }
    }
}
