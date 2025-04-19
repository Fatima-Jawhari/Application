using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp1.Core.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public required string Content { get; set; }
        public DateTime SentAt { get; set; }

        public int GroupId { get; set; }
        public required Group Group { get; set; }

        public required string SenderId { get; set; }
        public required ApplicationUser Sender { get; set; }
    }
}
