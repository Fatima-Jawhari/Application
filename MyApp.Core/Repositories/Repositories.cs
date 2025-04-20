

using MyApp1.Core.Entities;
using MyApp1.Infrastructure.Data;
using MyApp1.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using MyApp1.Core.Interfaces;

namespace MyApp1.Infrastructure.Repositories
{

    public class CommunityMembershipRepository : ICommunityMembershipRepository
    {
        private readonly ApplicationDbContext _context;
        public CommunityMembershipRepository(ApplicationDbContext context) => _context = context;

        public async Task JoinAsync(Guid userId, Guid communityId)
        {
            var membership = new CommunityMembership { UserId = userId, CommunityId = communityId };
            await _context.CommunityMemberships.AddAsync(membership);
            await _context.SaveChangesAsync();
        }

        public async Task LeaveAsync(Guid userId, Guid communityId)
        {
            var membership = await _context.CommunityMemberships
                .FirstOrDefaultAsync(m => m.UserId == userId && m.CommunityId == communityId);
            if (membership != null)
            {
                _context.CommunityMemberships.Remove(membership);
                await _context.SaveChangesAsync();
            }
        }
    }

    public class EventParticipantRepository : IEventParticipantRepository
    {
        private readonly ApplicationDbContext _context;
        public EventParticipantRepository(ApplicationDbContext context) => _context = context;

        public async Task JoinAsync(Guid userId, Guid eventId)
        {
            var participant = new EventParticipant { UserId = userId, EventId = eventId };
            await _context.EventParticipants.AddAsync(participant);
            await _context.SaveChangesAsync();
        }

        public async Task LeaveAsync(Guid userId, Guid eventId)
        {
            var participant = await _context.EventParticipants
                .FirstOrDefaultAsync(p => p.UserId == userId && p.EventId == eventId);
            if (participant != null)
            {
                _context.EventParticipants.Remove(participant);
                await _context.SaveChangesAsync();
            }
        }
    }

    public class GroupMemberRepository : IGroupMemberRepository
    {
        private readonly ApplicationDbContext _context;
        public GroupMemberRepository(ApplicationDbContext context) => _context = context;

        public async Task AddMemberAsync(Guid groupId, Guid userId)
        {
            var member = new GroupMember { GroupId = groupId, UserId = userId };
            await _context.GroupMembers.AddAsync(member);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveMemberAsync(Guid groupId, Guid userId)
        {
            var member = await _context.GroupMembers
                .FirstOrDefaultAsync(m => m.GroupId == groupId && m.UserId == userId);
            if (member != null)
            {
                _context.GroupMembers.Remove(member);
                await _context.SaveChangesAsync();
            }
        }
    }

    public class HashtagRepository : IHashtagRepository
    {
        private readonly ApplicationDbContext _context;
        public HashtagRepository(ApplicationDbContext context) => _context = context;

        public async Task<IEnumerable<HashtagDto>> GetTrendingAsync()
        {
            return await _context.Hashtags
                .OrderByDescending(h => h.Id)
                .Take(10)
                .Select(h => new HashtagDto { Tag = h.Tag })
                .ToListAsync();
        }
    }

    public class LikeRepository : ILikeRepository
    {
        private readonly ApplicationDbContext _context;
        public LikeRepository(ApplicationDbContext context) => _context = context;

        public async Task LikeAsync(Guid userId, Guid postId)
        {
            var like = new Like { UserId = userId, PostId = postId };
            await _context.Likes.AddAsync(like);
            await _context.SaveChangesAsync();
        }

        public async Task UnlikeAsync(Guid userId, Guid postId)
        {
            var like = await _context.Likes.FirstOrDefaultAsync(l => l.UserId == userId && l.PostId == postId);
            if (like != null)
            {
                _context.Likes.Remove(like);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<int> GetCountAsync(Guid postId)
        {
            return await _context.Likes.CountAsync(l => l.PostId == postId);
        }
    }

    public class MediaRepository : IMediaRepository
    {
        private readonly ApplicationDbContext _context;
        public MediaRepository(ApplicationDbContext context) => _context = context;

        public async Task<IEnumerable<Media>> GetByUserIdAsync(Guid userId)
        {
            return await _context.Media.Where(m => m.UserId == userId).ToListAsync();
        }

        public async Task AddAsync(Media media)
        {
            await _context.Media.AddAsync(media);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var media = await _context.Media.FindAsync(id);
            if (media != null)
            {
                _context.Media.Remove(media);
                await _context.SaveChangesAsync();
            }
        }
    }

    public class ReportRepository : IReportRepository
    {
        private readonly ApplicationDbContext _context;
        public ReportRepository(ApplicationDbContext context) => _context = context;

        public async Task<IEnumerable<Report>> GetAllAsync() => await _context.Reports.ToListAsync();
        public async Task AddAsync(Report report)
        {
            await _context.Reports.AddAsync(report);
            await _context.SaveChangesAsync();
        }
    }

    public class SettingRepository : ISettingRepository
    {
        private readonly ApplicationDbContext _context;
        public SettingRepository(ApplicationDbContext context) => _context = context;

        public async Task<Settings> GetByUserIdAsync(Guid userId)
        {
            return await _context.Settings.FirstOrDefaultAsync(s => s.UserId == userId);
        }

        public async Task UpdateAsync(Settings settings)
        {
            _context.Settings.Update(settings);
            await _context.SaveChangesAsync();
        }
    }

    public class UserConnectionRepository : IUserConnectionRepository
    {
        private readonly ApplicationDbContext _context;
        public UserConnectionRepository(ApplicationDbContext context) => _context = context;

        public async Task ConnectAsync(Guid userId, Guid connectedUserId)
        {
            var connection = new UserConnection { UserId = userId, ConnectedUserId = connectedUserId, ConnectedOn = DateTime.UtcNow };
            await _context.UserConnections.AddAsync(connection);
            await _context.SaveChangesAsync();
        }

        public async Task DisconnectAsync(Guid userId, Guid connectedUserId)
        {
            var connection = await _context.UserConnections
                .FirstOrDefaultAsync(c => c.UserId == userId && c.ConnectedUserId == connectedUserId);
            if (connection != null)
            {
                _context.UserConnections.Remove(connection);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Guid>> GetByUserIdAsync(Guid userId)
        {
            return await _context.UserConnections
                .Where(c => c.UserId == userId)
                .Select(c => c.ConnectedUserId)
                .ToListAsync();
        }
    }
}
