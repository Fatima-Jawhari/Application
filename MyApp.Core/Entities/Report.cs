using MyApp1.Core.Entities;

public class Report
{
    public int Id { get; set; }

    public required string ReporterId { get; set; }
    public required ApplicationUser Reporter { get; set; }

    public string? ReportedUserId { get; set; }
    public ApplicationUser? ReportedUser { get; set; }

    // 🔧 FIX: change from string? to int?
    public int? ReportedPostId { get; set; }
    public Post? ReportedPost { get; set; }

    public required string Reason { get; set; }
    public string? AdditionalDetails { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
