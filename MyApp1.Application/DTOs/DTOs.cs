using MyApp1.Core.Entities;

namespace MyApp1.Application.DTOs
{
    public class AdminActionDto
    {
        public Guid Id { get; set; }
        public string Action { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class ApplicationUserDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }

    public class BlockedUserDto
    {
        public Guid Id { get; set; }
        public Guid BlockerId { get; set; }
        public Guid BlockedId { get; set; }
        public DateTime BlockedAt { get; set; }
    }

    public class CommentDto
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class CommunityDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class CommunityMembershipDto
    {
        public Guid Id { get; set; }
        public Guid CommunityId { get; set; }
        public Guid UserId { get; set; }
    }

    public class EventDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
    }

    public class EventParticipantDto
    {
        public Guid Id { get; set; }
        public Guid EventId { get; set; }
        public Guid UserId { get; set; }
    }

    public class GroupDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class GroupMemberDto
    {
        public Guid Id { get; set; }
        public Guid GroupId { get; set; }
        public Guid UserId { get; set; }
    }

    public class HashtagDto
    {
        public Guid Id { get; set; }
        public string Tag { get; set; }
    }

    public class LikeDto
    {
        public Guid Id { get; set; }
        public Guid PostId { get; set; }
        public Guid UserId { get; set; }
    }

    public class MediaDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Url { get; set; }
        public string MediaType { get; set; }
    }

    public class MessageDto
    {
        public Guid Id { get; set; }
        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; }
        public string Content { get; set; }
        public DateTime SentAt { get; set; }
    }

    public class NotificationDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class PostDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class ReportDto
    {
        public Guid Id { get; set; }
        public Guid ReporterId { get; set; }
        public string Reason { get; set; }
        public DateTime ReportedAt { get; set; }
    }

    public class SavedPostDto
    {
        public Guid UserId { get; set; }
        public Guid PostId { get; set; }
        public DateTime SavedAt { get; set; }
    }

    public class SettingDto
    {
        public Guid UserId { get; set; }
        public bool IsPrivate { get; set; }
        public bool NotificationsEnabled { get; set; }
    }

    public class UserConnectionDto
    {
        public Guid UserId { get; set; }
        public Guid ConnectedUserId { get; set; }
        public DateTime ConnectedOn { get; set; }
    }
}
