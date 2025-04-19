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
        public DbSet<GroupMember> GroupMembers { get; set; }
        public DbSet<BlockedUser> BlockedUsers { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Community> Communities { get; set; }
        public DbSet<CommunityMembership> CommunityMemberships { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventParticipant> EventParticipants { get; set; }
        public DbSet<Hashtag> Hashtags { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Media> Media { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<SavedPost> SavedPosts { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<UserConnection> UserConnections { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasKey(p => p.PostID);
                entity.Property(p => p.Content).IsRequired();
                entity.Property(p => p.CreatedAt);

                entity.HasOne(p => p.User)
                    .WithMany()
                    .HasForeignKey(p => p.UserID)
                    .OnDelete(DeleteBehavior.Cascade); // ✅ keep cascade here (only one path)
            });


            // Comment Configuration
            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Content).IsRequired();
                entity.Property(c => c.CreatedAt);
                entity.HasOne(c => c.Post)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(c => c.PostId)
                    .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(c => c.User)
                    .WithMany()
                    .HasForeignKey(c => c.UserId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            // Like Configuration
            modelBuilder.Entity<Like>(entity =>
            {
                entity.HasKey(l => l.Id);
                entity.Property(l => l.LikedAt);
                entity.HasOne(l => l.Post)
                    .WithMany(p => p.Likes)
                    .HasForeignKey(l => l.PostId)
                    .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(l => l.User)
                    .WithMany()
                    .HasForeignKey(l => l.UserId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            // Media Configuration
            modelBuilder.Entity<Media>(entity =>
            {
                entity.HasKey(m => m.Id);
                entity.Property(m => m.Url).IsRequired();
                entity.Property(m => m.Type).IsRequired();
                entity.HasOne(m => m.Post)
                    .WithMany()
                    .HasForeignKey(m => m.PostId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Group Configuration
            modelBuilder.Entity<Group>(entity =>
            {
                entity.HasKey(g => g.Id);
                entity.Property(g => g.Name).IsRequired().HasMaxLength(100);
                entity.HasMany(g => g.Members)
                    .WithOne(gm => gm.Group)
                    .HasForeignKey(gm => gm.GroupId);
                entity.HasMany(g => g.Messages)
                    .WithOne(m => m.Group)
                    .HasForeignKey(m => m.GroupId);
            });

            // GroupMember Configuration
            modelBuilder.Entity<GroupMember>(entity =>
            {
                entity.HasKey(gm => gm.Id);
                entity.Property(gm => gm.JoinedAt).HasDefaultValueSql("GETDATE()");
                entity.Property(gm => gm.IsAdmin).HasDefaultValue(false);
                entity.HasOne(gm => gm.Group)
                    .WithMany(g => g.Members)
                    .HasForeignKey(gm => gm.GroupId)
                    .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(gm => gm.User)
                    .WithMany()
                    .HasForeignKey(gm => gm.UserId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            // Event Configuration
            modelBuilder.Entity<Event>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Description).IsRequired();
                entity.Property(e => e.EventDate).IsRequired();
                entity.HasOne(e => e.Community)
                    .WithMany()
                    .HasForeignKey(e => e.CommunityId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // EventParticipant Configuration
            modelBuilder.Entity<EventParticipant>(entity =>
            {
                entity.HasKey(ep => ep.Id);
                entity.Property(ep => ep.RegisteredAt).HasDefaultValueSql("GETDATE()");
                entity.HasOne(ep => ep.Event)
                    .WithMany()
                    .HasForeignKey(ep => ep.EventId)
                    .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(ep => ep.User)
                    .WithMany()
                    .HasForeignKey(ep => ep.UserId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            // Community Configuration
            modelBuilder.Entity<Community>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Name).IsRequired().HasMaxLength(100);
                entity.Property(c => c.Description).IsRequired();
                entity.Property(c => c.CreatedAt).HasDefaultValueSql("GETDATE()");
                entity.HasMany(c => c.Members)
                    .WithOne(cm => cm.Community)
                    .HasForeignKey(cm => cm.CommunityId);
            });

            // CommunityMembership Configuration
            modelBuilder.Entity<CommunityMembership>(entity =>
            {
                entity.HasKey(cm => cm.Id);
                entity.Property(cm => cm.JoinedAt).HasDefaultValueSql("GETDATE()");
                entity.HasOne(cm => cm.Community)
                    .WithMany(c => c.Members)
                    .HasForeignKey(cm => cm.CommunityId)
                    .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(cm => cm.User)
                    .WithMany()
                    .HasForeignKey(cm => cm.UserId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            // Message Configuration
            modelBuilder.Entity<Message>(entity =>
            {
                entity.HasKey(m => m.Id);
                entity.Property(m => m.Content).IsRequired();
                entity.Property(m => m.SentAt);
                entity.HasOne(m => m.Group)
                    .WithMany(g => g.Messages)
                    .HasForeignKey(m => m.GroupId);
                entity.HasOne(m => m.Sender)
                    .WithMany()
                    .HasForeignKey(m => m.SenderId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            // Notification Configuration
            modelBuilder.Entity<Notification>(entity =>
            {
                entity.HasKey(n => n.Id);
                entity.Property(n => n.Title).IsRequired();
                entity.Property(n => n.Message).IsRequired();
                entity.Property(n => n.IsRead).HasDefaultValue(false);
                entity.Property(n => n.CreatedAt).HasDefaultValueSql("GETDATE()");
                entity.HasOne(n => n.User)
                    .WithMany()
                    .HasForeignKey(n => n.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Report Configuration
            modelBuilder.Entity<Report>(entity =>
            {
                entity.HasKey(r => r.Id);
                entity.Property(r => r.Reason).IsRequired();
                entity.Property(r => r.CreatedAt).HasDefaultValueSql("GETDATE()");
                entity.HasOne(r => r.Reporter)
                    .WithMany()
                    .HasForeignKey(r => r.ReporterId)
                    .OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(r => r.ReportedUser)
                    .WithMany()
                    .HasForeignKey(r => r.ReportedUserId)
                    .OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(r => r.ReportedPost)
                    .WithMany()
                    .HasForeignKey(r => r.ReportedPostId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            // SavedPost Configuration
            modelBuilder.Entity<SavedPost>(entity =>
            {
                entity.HasKey(sp => sp.Id);
                entity.Property(sp => sp.SavedAt).HasDefaultValueSql("GETDATE()");

                entity.HasOne(sp => sp.User)
                    .WithMany()
                    .HasForeignKey(sp => sp.UserId)
                    .OnDelete(DeleteBehavior.NoAction); // 

                entity.HasOne(sp => sp.Post)
                    .WithMany()
                    .HasForeignKey(sp => sp.PostId)
                    .OnDelete(DeleteBehavior.NoAction); //
            });



            // Setting Configuration
            modelBuilder.Entity<Setting>(entity =>
            {
                entity.HasKey(s => s.Id);
                entity.Property(s => s.ReceiveEmailNotifications).HasDefaultValue(true);
                entity.Property(s => s.ReceivePushNotifications).HasDefaultValue(true);
                entity.Property(s => s.IsPrivateProfile).HasDefaultValue(false);
                entity.Property(s => s.UpdatedAt).HasDefaultValueSql("GETDATE()");
                entity.HasOne(s => s.User)
                    .WithMany()
                    .HasForeignKey(s => s.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // BlockedUser Configuration
            modelBuilder.Entity<BlockedUser>(entity =>
            {
                entity.HasKey(b => b.Id);
                entity.Property(b => b.BlockedDate).HasDefaultValueSql("GETDATE()");
                entity.HasOne(b => b.Blocker)
                    .WithMany()
                    .HasForeignKey(b => b.BlockerId)
                    .OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(b => b.Blocked)
                    .WithMany()
                    .HasForeignKey(b => b.BlockedId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // UserConnection Configuration
            modelBuilder.Entity<UserConnection>(entity =>
            {
                entity.HasKey(uc => uc.Id);
                entity.Property(uc => uc.ConnectedAt).HasDefaultValueSql("GETDATE()");
                entity.HasOne(uc => uc.Follower)
                    .WithMany()
                    .HasForeignKey(uc => uc.FollowerId)
                    .OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(uc => uc.Followee)
                    .WithMany()
                    .HasForeignKey(uc => uc.FolloweeId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            // Hashtag Configuration
            modelBuilder.Entity<Hashtag>(entity =>
            {
                entity.HasKey(h => h.Id);
                entity.Property(h => h.Tag).IsRequired();
            });

            // Correct many-to-many configuration
            modelBuilder.Entity<Post>()
                .HasMany(p => p.Hashtags)
                .WithMany(h => h.Posts)
                .UsingEntity<Dictionary<string, object>>(
                    "PostHashtag",
                    j => j.HasOne<Hashtag>().WithMany().HasForeignKey("HashtagId"),
                    j => j.HasOne<Post>().WithMany().HasForeignKey("PostId"),
                    j => j.ToTable("PostHashtags"));
        }

    }
}