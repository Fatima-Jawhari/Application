using AutoMapper;
using MyApp1.Application.DTOs;
using MyApp1.Core.Entities;
using MyApp1.Application.ServicesInterfaces;
using MyApp1.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MyApp1.Application.Services
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

        public async Task<IEnumerable<EventDto>> GetAllAsync()
        {
            var events = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<EventDto>>(events);
        }

        public async Task<EventDto> GetByIdAsync(Guid id)
        {
            var eventEntity = await _repository.GetByIdAsync(id);
            if (eventEntity == null)
                throw new KeyNotFoundException($"Event with ID {id} was not found.");
            return _mapper.Map<EventDto>(eventEntity);
        }

        public async Task CreateAsync(EventDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto), "Event data cannot be null.");

            var eventEntity = _mapper.Map<Event>(dto);

            // Business logic example: prevent creating past events
            if (eventEntity.EventDate < DateTime.UtcNow)
                throw new InvalidOperationException("Event date must be set in the future.");

            await _repository.AddAsync(eventEntity);
        }

        public async Task UpdateAsync(EventDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto), "Event data cannot be null.");

            var existingEvent = await _repository.GetByIdAsync(dto.Id);
            if (existingEvent == null)
                throw new KeyNotFoundException($"Event with ID {dto.Id} does not exist.");

            var updatedEvent = _mapper.Map<Event>(dto);
            await _repository.UpdateAsync(updatedEvent);
        }

        public async Task DeleteAsync(Guid id)
        {
            var eventEntity = await _repository.GetByIdAsync(id);
            if (eventEntity == null)
                throw new KeyNotFoundException($"Event with ID {id} does not exist.");

            await _repository.DeleteAsync(id);  // pass the id, not the entity
        }
    }

    public class EventParticipantService : IEventParticipantService
    {
        private readonly IEventParticipantRepository _repository;
        private readonly IMapper _mapper;

        public EventParticipantService(IEventParticipantRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EventParticipant>> GetAsync(Guid id)
        {
            var participant = await _repository.GetAsync(id);
            return participant.Select(p => new EventParticipant
            {
                Id = p.Id,
                EventId = p.EventId,
                UserId = p.UserId,
                RegisteredAt = p.RegisteredAt,
            });
        }

        public async Task JoinEventAsync(Guid userId, Guid eventId)
        {
            var participant = new EventParticipant { UserId = userId, EventId = eventId, RegisteredAt = DateTime.UtcNow };
            await _repository.JoinAsync(userId,eventId);
        }

        public async Task LeaveEventAsync(Guid userId, Guid eventId)
        {
            await _repository.LeaveAsync(userId, eventId);
        }
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

        public async Task<IEnumerable<GroupDto>> GetAllAsync()
        {
            var groups = await _repository.GetAllAsync();
            return groups.Select(g => new GroupDto
            {
                Id = Guid.NewGuid(),
                Name = g.Name
            });
        }

        public async Task CreateAsync(GroupDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto), "Group data cannot be null.");

            var group = new Group
            {
                Name = dto.Name,
                Members = new List<GroupMember>(),
                Messages = new List<Message>()
            };

            await _repository.AddAsync(group);
        }
    }

    public class GroupMemberService : IGroupMemberService
    {
        private readonly IGroupMemberRepository _repository;

        public GroupMemberService(IGroupMemberRepository repository)
        {
            _repository = repository;
        }

        public async Task AddMemberAsync(Guid groupId, Guid userId)
        {
            if (groupId == Guid.Empty || userId == Guid.Empty)
                throw new ArgumentException("Group ID and User ID must be valid GUIDs.");

            var groupMember = new GroupMember
            {
                GroupId = ConvertGuidToInt(groupId),
                UserId = ConvertGuidToInt(userId),
                JoinedAt = DateTime.UtcNow,
                IsAdmin = false
            };

            await _repository.AddMemberAsync(groupMember);
        }

        public async Task RemoveMemberAsync(Guid groupId, Guid userId)
        {
            if (groupId == Guid.Empty || userId == Guid.Empty)
                throw new ArgumentException("Group ID and User ID must be valid GUIDs.");

            await _repository.RemoveMemberAsync(groupId, userId);
        }

        public async Task<IEnumerable<GroupMemberDto>> GetAllAsync()
        {
            var members = await _repository.GetAllAsync();
            return members.Select(m => new GroupMemberDto
            {
                Id = Guid.NewGuid(),
                GroupId = ConvertIntToGuid(m.GroupId), 
                UserId = ConvertIntToGuid(m.UserId) 
            });
        }

        private int ConvertGuidToInt(Guid guid)
        {
            return BitConverter.ToInt32(guid.ToByteArray(), 0);
        }
        public Guid ConvertIntToGuid(int value)
        {
            byte[] bytes = new byte[16];
            BitConverter.GetBytes(value).CopyTo(bytes, 0);
            return new Guid(bytes);
        }
    }



    public class HashtagService : IHashtagService
    {
        private readonly IHashtagRepository _repository;
        private readonly IMapper _mapper;

        public HashtagService(IHashtagRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<HashtagDto>> GetTrendingAsync()
        {
            var trendingHashtags = await _repository.GetTrendingAsync();
            return _mapper.Map<IEnumerable<HashtagDto>>(trendingHashtags);

        }

    }

    public class LikeService : ILikeService
    {
        private readonly ILikeRepository _repository;

        public LikeService(ILikeRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> GetLikeCountAsync(Guid postId)
        {
            return await _repository.GetCountAsync(postId);
        }

        public async Task LikePostAsync(Guid userId, Guid postId)
        {
            var like = new Like
            {
                UserId = userId,
                PostId = postId,
                LikedAt = DateTime.UtcNow
            };

            await _repository.LikeAsync(like);
        }

        public async Task UnlikePostAsync(Guid userId, Guid postId)
        {
            await _repository.UnlikeAsync(userId, postId);
        }
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

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<MediaDto>> GetUserMediaAsync(Guid userId)
        {
            var media = await _repository.GetByUserIdAsync(userId);
            return _mapper.Map<IEnumerable<MediaDto>>(media);
        }

        public async Task UploadAsync(MediaDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            var media = _mapper.Map<Media>(dto);
            await _repository.AddAsync(media);
        }

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

        public async Task<IEnumerable<MessageDto>> GetByUserAsync(Guid userId)
        {
            var messages = await _repository.GetByUserIdAsync(userId);
            return _mapper.Map<IEnumerable<MessageDto>>(messages);
        }

        public async Task SendMessageAsync(MessageDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            var message = _mapper.Map<Message>(dto);
            await _repository.AddAsync(message);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }
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

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<NotificationDto>> GetByUserIdAsync(Guid userId)
        {
            var notifications = await _repository.GetByUserIdAsync(userId);
            return _mapper.Map<IEnumerable<NotificationDto>>(notifications);
        }

        public async Task SendNotificationAsync(NotificationDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            var notification = _mapper.Map<Notification>(dto);
            await _repository.SendAsync(notification);
        }
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

        public Task CreateAsync(PostDto dto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PostDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PostDto> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(PostDto dto)
        {
            throw new NotImplementedException();
        }

        //public async Task<IEnumerable<PostDto>> GetAllAsync() =>
        //    _mapper.Map<IEnumerable<PostDto>>(await _repository.GetAllAsync());

        //public async Task<PostDto> GetByIdAsync(Guid id) =>
        //    _mapper.Map<PostDto>(await _repository.GetByIdAsync(id));

        //public async Task CreateAsync(PostDto dto) =>
        //    await _repository.AddAsync(_mapper.Map<Post>(dto));

        //public async Task UpdateAsync(PostDto dto) =>
        //    await _repository.UpdateAsync(_mapper.Map<Post>(dto));

        //public async Task DeleteAsync(Guid id) =>
        //    await _repository.DeleteAsync(id);
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

        public Task<IEnumerable<ReportDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task SubmitReportAsync(ReportDto dto)
        {
            throw new NotImplementedException();
        }

        //public async Task<IEnumerable<ReportDto>> GetAllAsync() =>
        //    _mapper.Map<IEnumerable<ReportDto>>(await _repository.GetAllAsync());

        //public async Task SubmitReportAsync(ReportDto dto) =>
        //    await _repository.AddAsync(_mapper.Map<Report>(dto));
    }

    public class SavedPostService : ISavedPostService
    {
        private readonly ISavedPostRepository _repository;

        public SavedPostService(ISavedPostRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Guid>> GetSavedPostsAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task SavePostAsync(Guid userId, Guid postId)
        {
            throw new NotImplementedException();
        }

        public Task UnsavePostAsync(Guid userId, Guid postId)
        {
            throw new NotImplementedException();
        }

        //public async Task SavePostAsync(Guid userId, Guid postId) =>
        //    await _repository.SaveAsync(userId, postId);

        //public async Task UnsavePostAsync(Guid userId, Guid postId) =>
        //    await _repository.UnsaveAsync(userId, postId);

        //public async Task<IEnumerable<Guid>> GetSavedPostsAsync(Guid userId) =>
        //    await _repository.GetByUserIdAsync(userId);
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

        public Task<SettingDto> GetUserSettingsAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateSettingsAsync(SettingDto dto)
        {
            throw new NotImplementedException();
        }

        //public async Task<SettingDto> GetUserSettingsAsync(Guid userId) =>
        //    _mapper.Map<SettingDto>(await _repository.GetByUserIdAsync(userId));

        //public async Task UpdateSettingsAsync(SettingDto dto) =>
        //    await _repository.UpdateAsync(_mapper.Map<Setting>(dto));
    }

    public class UserConnectionService : IUserConnectionService
    {
        private readonly IUserConnectionRepository _repository;

        public UserConnectionService(IUserConnectionRepository repository)
        {
            _repository = repository;
        }

        public Task ConnectAsync(Guid userId, Guid otherUserId)
        {
            throw new NotImplementedException();
        }

        public Task DisconnectAsync(Guid userId, Guid otherUserId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Guid>> GetConnectionsAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        //public async Task ConnectAsync(Guid userId, Guid otherUserId) =>
        //    await _repository.ConnectAsync(userId, otherUserId);

        //public async Task DisconnectAsync(Guid userId, Guid otherUserId) =>
        //    await _repository.DisconnectAsync(userId, otherUserId);

        //public async Task<IEnumerable<Guid>> GetConnectionsAsync(Guid userId) =>
        //    await _repository.GetByUserIdAsync(userId);
    }
}