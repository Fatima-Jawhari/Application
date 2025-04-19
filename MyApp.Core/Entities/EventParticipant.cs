using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp1.Core.Entities
{
    public class EventParticipant
    {
        public int Id { get; set; }

        public int EventId { get; set; }
        public required Event Event { get; set; }

        public required string UserId { get; set; }
        public required  ApplicationUser User { get; set; }

        public DateTime RegisteredAt { get; set; }
    }
}
