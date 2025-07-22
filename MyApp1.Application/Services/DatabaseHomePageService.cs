using Microsoft.EntityFrameworkCore;
using MyApp1.Core.Entities;
using MyApp1.Core.Interfaces;
using MyApp1.Infrastructure.Data;

namespace MyApp1.Application.Services
{
    public class DatabaseHomePageService : IHomePageService
    {
        private readonly ApplicationDbContext _context;

        public DatabaseHomePageService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<HomePageContent> GetHomePageContentAsync()
        {
            var contentEntity = await _context.HomePageContents
                .Include(h => h.Stats.OrderBy(s => s.Order))
                .Include(h => h.Features.OrderBy(f => f.Order))
                .Include(h => h.Testimonials.OrderBy(t => t.Order))
                .Include(h => h.Events.OrderBy(e => e.Order))
                .FirstOrDefaultAsync();

            if (contentEntity == null)
            {
                // Return default content if none exists in database
                return await GetDefaultContent();
            }

            return MapToDto(contentEntity);
        }

        public async Task<List<EventCard>> GetUpcomingEventsAsync(int count = 3)
        {
            var events = await _context.EventCards
                .Where(e => e.Date >= DateTime.Today)
                .OrderBy(e => e.Date)
                .Take(count)
                .ToListAsync();

            return events.Select(e => new EventCard
            {
                Date = e.Date,
                Title = e.Title,
                Description = e.Description,
                Location = e.Location,
                ImageUrl = e.ImageUrl,
                RsvpLink = e.RsvpLink
            }).ToList();
        }

        public async Task<List<TestimonialCard>> GetTestimonialsAsync(int count = 3)
        {
            var testimonials = await _context.TestimonialCards
                .OrderBy(t => t.Order)
                .Take(count)
                .ToListAsync();

            return testimonials.Select(t => new TestimonialCard
            {
                Text = t.Text,
                AuthorName = t.AuthorName,
                AuthorClass = t.AuthorClass,
                AuthorDepartment = t.AuthorDepartment,
                AuthorImageUrl = t.AuthorImageUrl
            }).ToList();
        }

        public async Task<List<FeatureCard>> GetFeaturesAsync()
        {
            var features = await _context.FeatureCards
                .OrderBy(f => f.Order)
                .ToListAsync();

            return features.Select(f => new FeatureCard
            {
                Icon = f.Icon,
                Title = f.Title,
                Description = f.Description,
                Link = f.Link
            }).ToList();
        }

        public async Task SaveHomePageContentAsync(HomePageContent content)
        {
            var existingContent = await _context.HomePageContents
                .Include(h => h.Stats)
                .Include(h => h.Features)
                .Include(h => h.Testimonials)
                .Include(h => h.Events)
                .FirstOrDefaultAsync();

            if (existingContent == null)
            {
                // Create new content
                var newContent = MapToEntity(content);
                _context.HomePageContents.Add(newContent);
            }
            else
            {
                // Update existing content
                UpdateEntity(existingContent, content);
                existingContent.UpdatedAt = DateTime.UtcNow;
            }

            await _context.SaveChangesAsync();
        }

        private async Task<HomePageContent> GetDefaultContent()
        {
            // Return the same default content as the in-memory service
            var defaultService = new HomePageService();
            return await defaultService.GetHomePageContentAsync();
        }

        private static HomePageContent MapToDto(HomePageContentEntity entity)
        {
            return new HomePageContent
            {
                Hero = new HeroContent
                {
                    Title = entity.HeroTitle,
                    Subtitle = entity.HeroSubtitle,
                    CallToActionText = entity.HeroCallToActionText,
                    CallToActionLink = entity.HeroCallToActionLink,
                    ImageUrl = entity.HeroImageUrl,
                    ImageAlt = entity.HeroImageAlt,
                    Stats = entity.Stats.Select(s => new StatItem
                    {
                        Number = s.Number,
                        Label = s.Label
                    }).ToList()
                },
                FeaturesSection = new SectionHeader
                {
                    Title = entity.FeaturesSectionTitle,
                    Subtitle = entity.FeaturesSectionSubtitle
                },
                Features = entity.Features.Select(f => new FeatureCard
                {
                    Icon = f.Icon,
                    Title = f.Title,
                    Description = f.Description,
                    Link = f.Link
                }).ToList(),
                TestimonialsSection = new SectionHeader
                {
                    Title = entity.TestimonialsSectionTitle,
                    Subtitle = entity.TestimonialsSectionSubtitle
                },
                Testimonials = entity.Testimonials.Select(t => new TestimonialCard
                {
                    Text = t.Text,
                    AuthorName = t.AuthorName,
                    AuthorClass = t.AuthorClass,
                    AuthorDepartment = t.AuthorDepartment,
                    AuthorImageUrl = t.AuthorImageUrl
                }).ToList(),
                EventsSection = new SectionHeader
                {
                    Title = entity.EventsSectionTitle,
                    Subtitle = entity.EventsSectionSubtitle
                },
                Events = entity.Events.Select(e => new EventCard
                {
                    Date = e.Date,
                    Title = e.Title,
                    Description = e.Description,
                    Location = e.Location,
                    ImageUrl = e.ImageUrl,
                    RsvpLink = e.RsvpLink
                }).ToList(),
                WhyYouniSection = new SectionHeader
                {
                    Title = entity.WhyYouniSectionTitle,
                    Subtitle = entity.WhyYouniSectionSubtitle
                }
            };
        }

        private static HomePageContentEntity MapToEntity(HomePageContent content)
        {
            var entity = new HomePageContentEntity
            {
                HeroTitle = content.Hero.Title,
                HeroSubtitle = content.Hero.Subtitle,
                HeroCallToActionText = content.Hero.CallToActionText,
                HeroCallToActionLink = content.Hero.CallToActionLink,
                HeroImageUrl = content.Hero.ImageUrl,
                HeroImageAlt = content.Hero.ImageAlt,
                FeaturesSectionTitle = content.FeaturesSection.Title,
                FeaturesSectionSubtitle = content.FeaturesSection.Subtitle,
                TestimonialsSectionTitle = content.TestimonialsSection.Title,
                TestimonialsSectionSubtitle = content.TestimonialsSection.Subtitle,
                EventsSectionTitle = content.EventsSection.Title,
                EventsSectionSubtitle = content.EventsSection.Subtitle,
                WhyYouniSectionTitle = content.WhyYouniSection.Title,
                WhyYouniSectionSubtitle = content.WhyYouniSection.Subtitle
            };

            // Map stats
            for (int i = 0; i < content.Hero.Stats.Count; i++)
            {
                entity.Stats.Add(new StatItemEntity
                {
                    Number = content.Hero.Stats[i].Number,
                    Label = content.Hero.Stats[i].Label,
                    Order = i
                });
            }

            // Map features
            for (int i = 0; i < content.Features.Count; i++)
            {
                entity.Features.Add(new FeatureCardEntity
                {
                    Icon = content.Features[i].Icon,
                    Title = content.Features[i].Title,
                    Description = content.Features[i].Description,
                    Link = content.Features[i].Link,
                    Order = i
                });
            }

            // Map testimonials
            for (int i = 0; i < content.Testimonials.Count; i++)
            {
                entity.Testimonials.Add(new TestimonialCardEntity
                {
                    Text = content.Testimonials[i].Text,
                    AuthorName = content.Testimonials[i].AuthorName,
                    AuthorClass = content.Testimonials[i].AuthorClass,
                    AuthorDepartment = content.Testimonials[i].AuthorDepartment,
                    AuthorImageUrl = content.Testimonials[i].AuthorImageUrl,
                    Order = i
                });
            }

            // Map events
            for (int i = 0; i < content.Events.Count; i++)
            {
                entity.Events.Add(new EventCardEntity
                {
                    Date = content.Events[i].Date,
                    Title = content.Events[i].Title,
                    Description = content.Events[i].Description,
                    Location = content.Events[i].Location,
                    ImageUrl = content.Events[i].ImageUrl,
                    RsvpLink = content.Events[i].RsvpLink,
                    Order = i
                });
            }

            return entity;
        }

        private static void UpdateEntity(HomePageContentEntity entity, HomePageContent content)
        {
            // Update main content
            entity.HeroTitle = content.Hero.Title;
            entity.HeroSubtitle = content.Hero.Subtitle;
            entity.HeroCallToActionText = content.Hero.CallToActionText;
            entity.HeroCallToActionLink = content.Hero.CallToActionLink;
            entity.HeroImageUrl = content.Hero.ImageUrl;
            entity.HeroImageAlt = content.Hero.ImageAlt;
            entity.FeaturesSectionTitle = content.FeaturesSection.Title;
            entity.FeaturesSectionSubtitle = content.FeaturesSection.Subtitle;
            entity.TestimonialsSectionTitle = content.TestimonialsSection.Title;
            entity.TestimonialsSectionSubtitle = content.TestimonialsSection.Subtitle;
            entity.EventsSectionTitle = content.EventsSection.Title;
            entity.EventsSectionSubtitle = content.EventsSection.Subtitle;
            entity.WhyYouniSectionTitle = content.WhyYouniSection.Title;
            entity.WhyYouniSectionSubtitle = content.WhyYouniSection.Subtitle;

            // Update stats (simplified - in production you'd want more sophisticated updating)
            entity.Stats.Clear();
            for (int i = 0; i < content.Hero.Stats.Count; i++)
            {
                entity.Stats.Add(new StatItemEntity
                {
                    Number = content.Hero.Stats[i].Number,
                    Label = content.Hero.Stats[i].Label,
                    Order = i,
                    HomePageContentId = entity.Id
                });
            }
        }
    }
}