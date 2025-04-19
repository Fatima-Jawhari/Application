namespace MyApp1.Core.Entities
{
    public class GroupMember
    {
        public int Id { get; set; }  // Unique identifier for each group membership

        public int GroupId { get; set; }  // Reference to the Group this user belongs to
        public  required Group Group { get; set; }  // Navigation property to the Group entity

        public required string UserId { get; set; }  // Reference to the user who is a member of the group
        public required ApplicationUser User { get; set; }  // Navigation property to the User entity

        public DateTime JoinedAt { get; set; } = DateTime.UtcNow;  // Date and time when the user joined the group

        public bool IsAdmin { get; set; } = false;  // Whether the user is an admin of the group
    }

}