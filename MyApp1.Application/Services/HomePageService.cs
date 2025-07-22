using MyApp1.Core.Entities;
using MyApp1.Core.Interfaces;

namespace MyApp1.Application.Services
{
    public class HomePageService : IHomePageService
    {
        public async Task<HomePageContent> GetHomePageContentAsync()
        {
            // In a real application, this would fetch from a database or CMS
            var content = new HomePageContent
            {
                Hero = new HeroContent
                {
                    Title = "Reconnect with Your University Community",
                    Subtitle = "Youni is the platform for graduates to network, collaborate, and maintain lifelong connections with their alma mater.",
                    CallToActionText = "Join Now",
                    CallToActionLink = "#",
                    ImageUrl = "https://images.unsplash.com/photo-1522202176988-66273c2fd55f?auto=format&fit=crop&w=1471&q=80",
                    ImageAlt = "Alumni networking",
                    Stats = new List<StatItem>
                    {
                        new() { Number = "10K+", Label = "Alumni Connected" },
                        new() { Number = "500+", Label = "Events Yearly" },
                        new() { Number = "100+", Label = "Career Opportunities" }
                    }
                },
                FeaturesSection = new SectionHeader
                {
                    Title = "Platform Features",
                    Subtitle = "Built with precision and care—Youni brings the spirit of Friendship to alumni networking"
                },
                Features = await GetFeaturesAsync(),
                TestimonialsSection = new SectionHeader
                {
                    Title = "Success Stories",
                    Subtitle = "Real alumni. Real connections. Real impact."
                },
                Testimonials = await GetTestimonialsAsync(),
                EventsSection = new SectionHeader
                {
                    Title = "Upcoming Events",
                    Subtitle = "Opportunities to engage, learn, and grow."
                },
                Events = await GetUpcomingEventsAsync(),
                WhyYouniSection = new SectionHeader
                {
                    Title = "Why Youni ?",
                    Subtitle = "Youni bridges the gap between past and future—alumni, mentors, and professionals under one platform."
                }
            };

            return await Task.FromResult(content);
        }

        public async Task<List<EventCard>> GetUpcomingEventsAsync(int count = 3)
        {
            var events = new List<EventCard>
            {
                new()
                {
                    Date = new DateTime(2025, 8, 15),
                    Title = "Annual Alumni Reunion",
                    Description = "Reconnect and relive the best moments with peers and faculty.",
                    Location = "University Main Hall",
                    ImageUrl = "https://images.unsplash.com/photo-1492684223066-81342ee5ff30?auto=format&fit=crop&w=1470&q=80",
                    RsvpLink = "#"
                },
                new()
                {
                    Date = new DateTime(2025, 9, 10),
                    Title = "Global Alumni Career Fair",
                    Description = "Top hiring companies with exclusive offers for Youni users.",
                    Location = "Online / In-Person Hybrid",
                    ImageUrl = "https://images.unsplash.com/photo-1521737711867-e3b97375f902?auto=format&fit=crop&w=1470&q=80",
                    RsvpLink = "#"
                },
                new()
                {
                    Date = new DateTime(2025, 10, 1),
                    Title = "Mentorship Mixer",
                    Description = "Match with a mentor or mentee during this guided networking session.",
                    Location = "Innovation Center",
                    ImageUrl = "https://images.unsplash.com/photo-1521791055366-0d553872125f?auto=format&fit=crop&w=1469&q=80",
                    RsvpLink = "#"
                }
            };

            return await Task.FromResult(events.Take(count).ToList());
        }

        public async Task<List<TestimonialCard>> GetTestimonialsAsync(int count = 3)
        {
            var testimonials = new List<TestimonialCard>
            {
                new()
                {
                    Text = "I found my old project team on Elevana—now we're running a funded startup!",
                    AuthorName = "Ali H.",
                    AuthorClass = "Class of 2013",
                    AuthorDepartment = "Engineering",
                    AuthorImageUrl = "https://randomuser.me/api/portraits/men/32.jpg"
                },
                new()
                {
                    Text = "The mentorship feature helped me land my first job after graduation.",
                    AuthorName = "Lina Z.",
                    AuthorClass = "Class of 2020",
                    AuthorDepartment = "Business",
                    AuthorImageUrl = "https://randomuser.me/api/portraits/women/68.jpg"
                },
                new()
                {
                    Text = "It's amazing to stay connected with students and alumni across the world.",
                    AuthorName = "Dr. Marwan K.",
                    AuthorClass = "Faculty",
                    AuthorDepartment = "Computer Science",
                    AuthorImageUrl = "https://randomuser.me/api/portraits/men/75.jpg"
                }
            };

            return await Task.FromResult(testimonials.Take(count).ToList());
        }

        public async Task<List<FeatureCard>> GetFeaturesAsync()
        {
            var features = new List<FeatureCard>
            {
                new()
                {
                    Icon = "fas fa-users",
                    Title = "Networking Hub",
                    Description = "Connect with alumni from various faculties, years, and regions.",
                    Link = "#"
                },
                new()
                {
                    Icon = "fas fa-calendar-check",
                    Title = "Event Management",
                    Description = "Discover and RSVP to reunions, conferences, and meetups.",
                    Link = "#"
                },
                new()
                {
                    Icon = "fas fa-briefcase",
                    Title = "Career Center",
                    Description = "Access exclusive opportunities shared by alumni and partners.",
                    Link = "#"
                },
                new()
                {
                    Icon = "fas fa-comments",
                    Title = "Direct Messaging",
                    Description = "1:1 or group chats with real-time messaging and video support.",
                    Link = "#"
                },
                new()
                {
                    Icon = "fas fa-newspaper",
                    Title = "Alumni Newsfeed",
                    Description = "Stay updated with academic and professional milestones.",
                    Link = "#"
                },
                new()
                {
                    Icon = "fas fa-graduation-cap",
                    Title = "Mentorship Program",
                    Description = "Support or receive guidance in a structured mentor-mentee system.",
                    Link = "#"
                }
            };

            return await Task.FromResult(features);
        }

        public async Task SaveHomePageContentAsync(HomePageContent content)
        {
            // In-memory service doesn't persist data
            // This is just for interface compliance
            await Task.CompletedTask;
        }
    }
}