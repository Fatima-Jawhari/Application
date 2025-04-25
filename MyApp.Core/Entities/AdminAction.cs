using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp1.Core.Entities
{
    public class AdminAction
    {
        public int Id { get; set; }
        public  required string ActionType { get; set; }
        public DateTime PerformedAt { get; set; }
      
        // Other properties...
    }
}
