using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp1.Core.Entities
{
    public class Hashtag
    {
        public int Id { get; set; }
        public required string Tag { get; set; }

        public required ICollection<Post> Posts { get; set; }
    }
}
