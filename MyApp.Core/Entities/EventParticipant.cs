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

        public required Guid EventId { get; set; }
        public Event Event { get; set; } = null!;

        public required Guid UserId { get; set; }
        public ApplicationUser User { get; set; } = null!;

        public DateTime RegisteredAt { get; set; }
    }
}
