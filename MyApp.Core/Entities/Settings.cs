using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp1.Core.Entities
{
    public class Setting
    {
        public int Id { get; set; }

        public required string UserId { get; set; }
        public required ApplicationUser User { get; set; }

        public bool ReceiveEmailNotifications { get; set; } = true;
        public bool ReceivePushNotifications { get; set; } = true;
        public bool IsPrivateProfile { get; set; } = false;

        public string? ThemePreference { get; set; } // e.g., "light", "dark", "system"

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }

}
