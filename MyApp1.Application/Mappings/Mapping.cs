using AutoMapper;
using MyApp1.Core.Entities;
using MyApp1.Application.DTOs;

namespace MyApp1.Application.Mappings
{
    public class AdminActionMappingProfile : Profile
    {
        public AdminActionMappingProfile()
        {
            CreateMap<AdminAction, AdminActionDto>().ReverseMap();
        }
    }

    public class ApplicationUserMappingProfile : Profile
    {
        public ApplicationUserMappingProfile()
        {
            CreateMap<ApplicationUser, ApplicationUserDto>().ReverseMap();
        }
    }

    public class BlockedUserMappingProfile : Profile
    {
        public BlockedUserMappingProfile()
        {
            CreateMap<BlockedUser, BlockedUserDto>().ReverseMap();
        }
    }

    public class CommentMappingProfile : Profile
    {
        public CommentMappingProfile()
        {
            CreateMap<Comment, CommentDto>().ReverseMap();
        }
    }

    public class CommunityMappingProfile : Profile
    {
        public CommunityMappingProfile()
        {
            CreateMap<Community, CommunityDto>().ReverseMap();
        }
    }

    public class CommunityMembershipMappingProfile : Profile
    {
        public CommunityMembershipMappingProfile()
        {
            CreateMap<CommunityMembership, CommunityMembershipDto>().ReverseMap();
        }
    }

    public class EventMappingProfile : Profile
    {
        public EventMappingProfile()
        {
            CreateMap<Event, EventDto>().ReverseMap();
        }
    }

    public class EventParticipantMappingProfile : Profile
    {
        public EventParticipantMappingProfile()
        {
            CreateMap<EventParticipant, EventParticipantDto>().ReverseMap();
        }
    }

    public class GroupMappingProfile : Profile
    {
        public GroupMappingProfile()
        {
            CreateMap<Group, GroupDto>().ReverseMap();
        }
    }

    public class GroupMemberMappingProfile : Profile
    {
        public GroupMemberMappingProfile()
        {
            CreateMap<GroupMember, GroupMemberDto>().ReverseMap();
        }
    }

    public class HashtagMappingProfile : Profile
    {
        public HashtagMappingProfile()
        {
            CreateMap<Hashtag, HashtagDto>().ReverseMap();
        }
    }

    public class LikeMappingProfile : Profile
    {
        public LikeMappingProfile()
        {
            CreateMap<Like, LikeDto>().ReverseMap();
        }
    }

    public class MediaMappingProfile : Profile
    {
        public MediaMappingProfile()
        {
            CreateMap<Media, MediaDto>().ReverseMap();
        }
    }

    public class MessageMappingProfile : Profile
    {
        public MessageMappingProfile()
        {
            CreateMap<Message, MessageDto>().ReverseMap();
        }
    }

    public class NotificationMappingProfile : Profile
    {
        public NotificationMappingProfile()
        {
            CreateMap<Notification, NotificationDto>().ReverseMap();
        }
    }

    public class PostMappingProfile : Profile
    {
        public PostMappingProfile()
        {
            CreateMap<Post, PostDto>().ReverseMap();
        }
    }

    public class ReportMappingProfile : Profile
    {
        public ReportMappingProfile()
        {
            CreateMap<Report, ReportDto>().ReverseMap();
        }
    }

    public class SavedPostMappingProfile : Profile
    {
        public SavedPostMappingProfile()
        {
            CreateMap<SavedPost, SavedPostDto>().ReverseMap();
        }
    }

    public class SettingMappingProfile : Profile
    {
        public SettingMappingProfile()
        {
            CreateMap<Setting, SettingDto>().ReverseMap();
        }
    }

    public class UserConnectionMappingProfile : Profile
    {
        public UserConnectionMappingProfile()
        {
            CreateMap<UserConnection, UserConnectionDto>().ReverseMap();
        }
    }
}
