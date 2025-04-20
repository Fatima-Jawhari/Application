using AutoMapper;
using MyApp1.Application.DTOs;
using MyApp1.Core.Entities;
using MyApp1.Application.


namespace AlumniConnect.Application.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _repository;
        private readonly IMapper _mapper;

        public EventService(IEventRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EventDto>> GetAllAsync() =>
            _mapper.Map<IEnumerable<EventDto>>(await _repository.GetAllAsync());

        public async Task<EventDto> GetByIdAsync(Guid id) =>
            _mapper.Map<EventDto>(await _repository.GetByIdAsync(id));

        public async Task CreateAsync(EventDto dto) =>
            await _repository.AddAsync(_mapper.Map<Event>(dto));

        public async Task UpdateAsync(EventDto dto) =>
            await _repository.UpdateAsync(_mapper.Map<Event>(dto));

        public async Task DeleteAsync(Guid id) =>
            await _repository.DeleteAsync(id);
    }

    public class EventParticipantService : IEventParticipantService
    {
        private readonly IEventParticipantRepository _repository;

        public EventParticipantService(IEventParticipantRepository repository)
        {
            _repository = repository;
        }

        public async Task JoinEventAsync(Guid userId, Guid eventId) =>
            await _repository.JoinAsync(userId, eventId);

        public async Task LeaveEventAsync(Guid userId, Guid eventId) =>
            await _repository.LeaveAsync(userId, eventId);
    }

    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _repository;
        private readonly IMapper _mapper;

        public GroupService(IGroupRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GroupDto>> GetAllAsync() =>
            _mapper.Map<IEnumerable<GroupDto>>(await _repository.GetAllAsync());

        public async Task CreateAsync(GroupDto dto) =>
            await _repository.AddAsync(_mapper.Map<Group>(dto));
    }

    public class GroupMemberService : IGroupMemberService
    {
        private readonly IGroupMemberRepository _repository;

        public GroupMemberService(IGroupMemberRepository repository)
        {
            _repository = repository;
        }

        public async Task AddMemberAsync(Guid groupId, Guid userId) =>
            await _repository.AddMemberAsync(groupId, userId);

        public async Task RemoveMemberAsync(Guid groupId, Guid userId) =>
            await _repository.RemoveMemberAsync(groupId, userId);
    }

    public class HashtagService : IHashtagService
    {
        private readonly IHashtagRepository _repository;

        public HashtagService(IHashtagRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<HashtagDto>> GetTrendingAsync() =>
            await _repository.GetTrendingAsync();
    }

    public class LikeService : ILikeService
    {
        private readonly ILikeRepository _repository;

        public LikeService(ILikeRepository repository)
        {
            _repository = repository;
        }

        public async Task LikePostAsync(Guid userId, Guid postId) =>
            await _repository.LikeAsync(userId, postId);

        public async Task UnlikePostAsync(Guid userId, Guid postId) =>
            await _repository.UnlikeAsync(userId, postId);

        public async Task<int> GetLikeCountAsync(Guid postId) =>
            await _repository.GetCountAsync(postId);
    }

    public class MediaService : IMediaService
    {
        private readonly IMediaRepository _repository;
        private readonly IMapper _mapper;

        public MediaService(IMediaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MediaDto>> GetUserMediaAsync(Guid userId) =>
            _mapper.Map<IEnumerable<MediaDto>>(await _repository.GetByUserIdAsync(userId));

        public async Task UploadAsync(MediaDto dto) =>
            await _repository.AddAsync(_mapper.Map<Media>(dto));

        public async Task DeleteAsync(Guid id) =>
            await _repository.DeleteAsync(id);
    }

    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _repository;
        private readonly IMapper _mapper;

        public MessageService(IMessageRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MessageDto>> GetByUserAsync(Guid userId) =>
            _mapper.Map<IEnumerable<MessageDto>>(await _repository.GetByUserIdAsync(userId));

        public async Task SendMessageAsync(MessageDto dto) =>
            await _repository.AddAsync(_mapper.Map<Message>(dto));

        public async Task DeleteAsync(Guid id) =>
            await _repository.DeleteAsync(id);
    }

    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _repository;
        private readonly IMapper _mapper;

        public NotificationService(INotificationRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<NotificationDto>> GetByUserIdAsync(Guid userId) =>
            _mapper.Map<IEnumerable<NotificationDto>>(await _repository.GetByUserIdAsync(userId));

        public async Task SendNotificationAsync(NotificationDto dto) =>
            await _repository.SendAsync(_mapper.Map<Notification>(dto));

        public async Task DeleteAsync(Guid id) =>
            await _repository.DeleteAsync(id);
    }

    public class PostService : IPostService
    {
        private readonly IPostRepository _repository;
        private readonly IMapper _mapper;

        public PostService(IPostRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PostDto>> GetAllAsync() =>
            _mapper.Map<IEnumerable<PostDto>>(await _repository.GetAllAsync());

        public async Task<PostDto> GetByIdAsync(Guid id) =>
            _mapper.Map<PostDto>(await _repository.GetByIdAsync(id));

        public async Task CreateAsync(PostDto dto) =>
            await _repository.AddAsync(_mapper.Map<Post>(dto));

        public async Task UpdateAsync(PostDto dto) =>
            await _repository.UpdateAsync(_mapper.Map<Post>(dto));

        public async Task DeleteAsync(Guid id) =>
            await _repository.DeleteAsync(id);
    }

    public class ReportService : IReportService
    {
        private readonly IReportRepository _repository;
        private readonly IMapper _mapper;

        public ReportService(IReportRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ReportDto>> GetAllAsync() =>
            _mapper.Map<IEnumerable<ReportDto>>(await _repository.GetAllAsync());

        public async Task SubmitReportAsync(ReportDto dto) =>
            await _repository.AddAsync(_mapper.Map<Report>(dto));
    }

    public class SavedPostService : ISavedPostService
    {
        private readonly ISavedPostRepository _repository;

        public SavedPostService(ISavedPostRepository repository)
        {
            _repository = repository;
        }

        public async Task SavePostAsync(Guid userId, Guid postId) =>
            await _repository.SaveAsync(userId, postId);

        public async Task UnsavePostAsync(Guid userId, Guid postId) =>
            await _repository.UnsaveAsync(userId, postId);

        public async Task<IEnumerable<Guid>> GetSavedPostsAsync(Guid userId) =>
            await _repository.GetByUserIdAsync(userId);
    }

    public class SettingService : ISettingService
    {
        private readonly ISettingRepository _repository;
        private readonly IMapper _mapper;

        public SettingService(ISettingRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<SettingDto> GetUserSettingsAsync(Guid userId) =>
            _mapper.Map<SettingDto>(await _repository.GetByUserIdAsync(userId));

        public async Task UpdateSettingsAsync(SettingDto dto) =>
            await _repository.UpdateAsync(_mapper.Map<Settings>(dto));
    }

    public class UserConnectionService : IUserConnectionService
    {
        private readonly IUserConnectionRepository _repository;

        public UserConnectionService(IUserConnectionRepository repository)
        {
            _repository = repository;
        }

        public async Task ConnectAsync(Guid userId, Guid otherUserId) =>
            await _repository.ConnectAsync(userId, otherUserId);

        public async Task DisconnectAsync(Guid userId, Guid otherUserId) =>
            await _repository.DisconnectAsync(userId, otherUserId);

        public async Task<IEnumerable<Guid>> GetConnectionsAsync(Guid userId) =>
            await _repository.GetByUserIdAsync(userId);
    }
}
s