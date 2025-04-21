

using MyApp1.Core.Entities;
using MyApp1.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;



namespace MyApp1.Infrastructure.Repositories
{

    public class CommunityMembershipRepository : ICommunityMembershipRepository
    {
        private readonly ApplicationDbContext _context;
        public CommunityMembershipRepository(ApplicationDbContext context) => _context = context;

        public Task<IEnumerable<ICommentRepository>> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task JoinAsync(CommunityMembership communityMembership)
        {
           _context.CommunityMembership.Add(communityMembership);
            await _context.SaveChangesAsync();
        }

        public async Task LeaveAsync(int id)
        {
            var communityMembership = _context.CommunityMembership.FirstOrDefault(m => m.Id == id);
            if (communityMembership = null) {
                throw new KeyNotFoundException($"Membership not found");
            }
            _context.CommunityMembership.Remove(communityMembership);
            await _context.SaveChangesAsync();
        }
    }

    public class EventParticipantRepository : IEventParticipantRepository
    {
        private readonly ApplicationDbContext _context;
        public EventParticipantRepository(ApplicationDbContext context) => _context = context;

        public async Task<IEnumerable<EventParticipant>> GetAsync(Guid eventId)
        {
            return await _context.EventParticipants
            .Where(p => p.EventId == eventId)
            .AsNoTracking()
            .ToListAsync();
        }

        public async Task<bool> ExistsAsync(Guid userId, Guid eventId)
        {
            return await _context.EventParticipants
                .AnyAsync(p => p.UserId == userId && p.EventId == eventId);
        }

        public async Task JoinAsync(EventParticipant participant)
        {
            // Validate no duplicate
            if (await ExistsAsync(participant.UserId, participant.EventId))
            {
                throw new InvalidOperationException(
                    $"User {participant.UserId} is already registered for event {participant.EventId}");
            }

            await _context.EventParticipants.AddAsync(participant);
            await _context.SaveChangesAsync();
        }

        public async Task LeaveAsync(Guid userId, Guid eventId)
        {
            var participant = await _context.EventParticipant.FirstOrDefualtAsync(p => p.UserId == userId && p.EventId == eventId);
            if (participant == null)
            {
                throw new KeyNotFoundException(
                    $"Participant not found for user and event");
            }

            _context.EventParticipants.Remove(participant);
            await _context.SaveChangesAsync();
        }
    }

    public class GroupMemberRepository : IGroupMemberRepository
    {
        private readonly ApplicationDbContext _context;
        public GroupMemberRepository(ApplicationDbContext context) => _context = context;

        public async Task<bool> ExistsAsync(int groupId, int userId)
        {
            return await _context.GroupMmebership
                .AnyAsync(p => p.UserId == userId && p.GroupId == groupId);
        }

        public async Task AddMemberAsync(GroupMember groupMember)
        {
            if (await ExistsAsync(groupMember.GroupId, groupMember.UserId))
            {
                throw new InvalidOperationException(
                    $"User is already rin the group");
            }
            await _context.GroupMembers.AddAsync(groupMember);
            await _context.SaveChangesAsync();
        }

        public Task<IEnumerable<GroupMember>> GetAllAsync()
        {
            throw new NotImplementedException();
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

        public async Task AddAsync(Hashtag hashtag)
        {
            await _context.Hashtags.Add(hashtag);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var hashtag = await _context.Hashtags.FirstOrDefaultAsync(m => m.Id == id);
            if (hashtag == null)
            {
                throw new KeyNotFoundException(
                    $"Hashtag not found");
            }
            await _context.Hashtags.Remove(hashtag);
            await _context.SaveChangesAsync();
        }

        public Task<IEnumerable<Hashtag>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Hashtag>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Hashtag>> GetTrendingAsync()
        {
            return await _context.Hashtags
                .OrderByDescending(h => h.Id)
                .Take(10)
                .Select(h => new Hashtag { Tag = h.Tag })
                .ToListAsync();
        }

        Task<IEnumerable<Hashtag>> IHashtagRepository.GetTrendingAsync()
        {
            throw new NotImplementedException();
        }
    }

    public class LikeRepository : ILikeRepository
    {
        private readonly ApplicationDbContext _context;
        public LikeRepository(ApplicationDbContext context) => _context = context;

        public async Task<bool> ExistsAsync(Guid postId, Guid userId)
        {
            return await _context.Likes
                .AnyAsync(p => p.UserId == userId && p.PostId == postId);
        }

        public async Task LikeAsync(Like like)
        {
            if (await ExistsAsync(like.PostId, like.UserId))
            {
                UnlikeAsync(like.UserId, like.PostId);
            }
            await _context.Likes.AddAsync(like);
            await _context.SaveChangesAsync();
        }

        public async Task UnlikeAsync(Guid userId, Guid postId)
        {
            if (await ExistsAsync(postId, userId))
            {
                var liked = await _context.Likes.FirstOrDefaultAsync(m => m.postId == postId && m.UserId == userId);
                LikeAsync(liked.UserId, liked.PostId);
            }
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

        public Task<IEnumerable<Like>> GetAlltAsync()
        {
            throw new NotImplementedException();
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

        public Task<IEnumerable<Media>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Media media)
        {
            throw new NotImplementedException();
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

        public async Task DeleteAsync(int id)
        {
            var report = await _context.Report.FirstOrDefaultAsync(m => m.Id == id);
            if (report == null)
            {
                throw new KeyNotFoundException(
                    $"Report not found");
            }
            await _context.Hashtags.Remove(report);
            await _context.SaveChangesAsync();
        }
    }

    public class SettingRepository : ISettingRepository
    {
        private readonly ApplicationDbContext _context;
        public SettingRepository(ApplicationDbContext context) => _context = context;

        public Task AddAsync(Setting setting)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Setting>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Setting> GetByUserIdAsync(Guid userId)
        {
            return await _context.Settings.FirstOrDefaultAsync(s => s.UserId == userId);
        }

        public async Task UpdateAsync(Setting settings)
        {
            _context.Settings.Update(settings);
            await _context.SaveChangesAsync();
        }

        Task<IEnumerable<Setting>> ISettingRepository.GetByUserIdAsync(Guid userId)
        {
            throw new NotImplementedException();
        }
    }

    public class UserConnectionRepository : IUserConnectionRepository
    {
        private readonly ApplicationDbContext _context;
        public UserConnectionRepository(ApplicationDbContext context) => _context = context;

        public async Task ConnectAsync(Guid userId, Guid connectedUserId)
        {
            var connection = new UserConnection { FollowedId = userId, FollowerId = connectedUserId, ConnectedAt = DateTime.UtcNow };
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

        public Task<IEnumerable<UserConnection>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserConnection>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
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
