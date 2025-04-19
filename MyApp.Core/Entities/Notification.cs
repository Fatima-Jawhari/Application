using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp1.Core.Entities
{
    public class Notification
    {
        public int Id { get; set; }

        public required string UserId { get; set; }  // The receiver of the notification
        public required ApplicationUser User { get; set; }

        public required string Title { get; set; }
        public required  string Message { get; set; }

        public bool IsRead { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public string? Link { get; set; } // Optional: URL or deep link to related content
        public string? Type { get; set; } // Optional: e.g., "comment", "like", "system", etc.
    }

}
