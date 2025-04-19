using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp1.Core.Entities
{
   public class Media
{
    public int Id { get; set; }
    public required string Url { get; set; }
    public required string Type { get; set; } // image, video, etc.

    public int PostId { get; set; }
    public required Post Post { get; set; }
}
}
