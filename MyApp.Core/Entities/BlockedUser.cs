using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp1.Core.Entities
{
    public class BlockedUser
    {
        public int Id { get; set; }

        public required string BlockerId { get; set; }
        public required ApplicationUser Blocker { get; set; }

        public  required string BlockedId { get; set; }
        public required ApplicationUser Blocked { get; set; }

        public DateTime BlockedDate { get; set; }
    }
}
