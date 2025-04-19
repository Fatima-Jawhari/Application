using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp1.Core.Entities
{
    public class Reports
    {
        public int Id { get; set; }

        public required  string ReporterId { get; set; }
        public required ApplicationUser Reporter { get; set; }

        public string? ReportedUserId { get; set; }
        public ApplicationUser? ReportedUser { get; set; }

        public string? ReportedPostId { get; set; }
        public Post? ReportedPost { get; set; }

        public required string Reason { get; set; }
        public string? AdditionalDetails { get; set; }

        public DateTime

    } 
}

