using MyApp1.Application.DTOs;

namespace MyApp1.Application.ServicesInterfaces
{
    public interface IAdminActionService
    {
        Task<IEnumerable<AdminActionDto>> GetAllAsync();
        Task CreateAsync(AdminActionDto dto);
    }

   
    public interface IBlockedUserService
    {
        Task<IEnumerable<BlockedUserDto>> GetAllAsync();
        Task BlockUserAsync(BlockedUserDto dto);
        Task UnblockUserAsync(BlockedUserDto dto);
    }

    public interface ICommentService
    {
        Task<IEnumerable<CommentDto>> GetAllAsync();
        Task<CommentDto> GetByIdAsync(Guid id);
        Task CreateAsync(CommentDto dto);
        Task DeleteAsync(Guid id);
    }

    public interface ICommunityService
    {
        Task<IEnumerable<CommunityDto>> GetAllAsync();
        Task CreateAsync(CommunityDto dto);
    }

    public interface ICommunityMembershipService
    {
        Task JoinAsync(Guid userId, Guid communityId);
        Task LeaveAsync(Guid userId, Guid communityId);
    }

    public interface IEventService
    {
        Task<IEnumerable<EventDto>> GetAllAsync();
        Task<EventDto> GetByIdAsync(Guid id);
        Task CreateAsync(EventDto dto);
        Task UpdateAsync(EventDto dto);
        Task DeleteAsync(Guid id);
    }

    public interface IEventParticipantService
    {
        Task JoinEventAsync(Guid userId, Guid eventId);
        Task LeaveEventAsync(Guid userId, Guid eventId);
    }

    public interface IGroupService
    {
        Task<IEnumerable<GroupDto>> GetAllAsync();
        Task CreateAsync(GroupDto dto);
    }

    public interface IGroupMemberService
    {
        Task AddMemberAsync(Guid groupId, Guid userId);
        Task RemoveMemberAsync(Guid groupId, Guid userId);
    }

    public interface IHashtagService
    {
        Task<IEnumerable<HashtagDto>> GetTrendingAsync();
    }

    public interface ILikeService
    {
        Task LikePostAsync(Guid userId, Guid postId);
        Task UnlikePostAsync(Guid userId, Guid postId);
        Task<int> GetLikeCountAsync(Guid postId);
    }

    public interface IMediaService
    {
        Task<IEnumerable<MediaDto>> GetUserMediaAsync(Guid userId);
        Task UploadAsync(MediaDto dto);
        Task DeleteAsync(Guid id);
    }

    public interface IMessageService
    {
        Task<IEnumerable<MessageDto>> GetByUserAsync(Guid userId);
        Task SendMessageAsync(MessageDto dto);
        Task DeleteAsync(Guid id);
    }

    public interface INotificationService
    {
        Task<IEnumerable<NotificationDto>> GetByUserIdAsync(Guid userId);
        Task SendNotificationAsync(NotificationDto dto);
        Task DeleteAsync(Guid id);
    }

    public interface IPostService
    {
        Task<IEnumerable<PostDto>> GetAllAsync();
        Task<PostDto> GetByIdAsync(Guid id);
        Task CreateAsync(PostDto dto);
        Task UpdateAsync(PostDto dto);
        Task DeleteAsync(Guid id);
    }

    public interface IReportService
    {
        Task<IEnumerable<ReportDto>> GetAllAsync();
        Task SubmitReportAsync(ReportDto dto);
    }

    public interface ISavedPostService
    {
        Task SavePostAsync(Guid userId, Guid postId);
        Task UnsavePostAsync(Guid userId, Guid postId);
        Task<IEnumerable<Guid>> GetSavedPostsAsync(Guid userId);
    }

    public interface ISettingService
    {
        Task<SettingDto> GetUserSettingsAsync(Guid userId);
        Task UpdateSettingsAsync(SettingDto dto);
    }

    public interface IUserConnectionService
    {
        Task ConnectAsync(Guid userId, Guid otherUserId);
        Task DisconnectAsync(Guid userId, Guid otherUserId);
        Task<IEnumerable<Guid>> GetConnectionsAsync(Guid userId);
    }
}