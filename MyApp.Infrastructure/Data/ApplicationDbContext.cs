using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyApp1.Core.Entities;

namespace MyApp1.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<BlockedUser> BlockedUsers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure BlockedUser relationships
            modelBuilder.Entity<BlockedUser>()
                .HasOne(b => b.Blocker)
                .WithMany()
                .HasForeignKey(b => b.BlockerId)
                .OnDelete(DeleteBehavior.NoAction);  // Blocker no cascade delete

            modelBuilder.Entity<BlockedUser>()
                .HasOne(b => b.Blocked)
                .WithMany()
                .HasForeignKey(b => b.BlockedId)
                .OnDelete(DeleteBehavior.Cascade);  // Blocked cascade delete
        }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Community> Communities { get; set; }
        public DbSet<CommunityMembership> CommunityMemberships { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventParticipant> EventParticipants { get; set; }
        public DbSet<GroupMember> GroupMembers { get; set; }
        public DbSet<Hashtag> Hashtags { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Media> Media { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<SavedPost> SavedPosts { get; set; }
        public DbSet<Setting> Settings { get; set; }
    }
}

