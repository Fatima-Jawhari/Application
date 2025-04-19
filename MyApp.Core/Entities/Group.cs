using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp1.Core.Entities
{
    public class Group
    {
        public int Id { get; set; }
        public required  string Name { get; set; }

        public required ICollection<GroupMember> Members { get; set; }
        public required ICollection<Message> Messages { get; set; }
    }
}
