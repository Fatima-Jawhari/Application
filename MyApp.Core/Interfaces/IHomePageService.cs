using MyApp1.Core.Entities;

namespace MyApp1.Core.Interfaces
{
    public interface IHomePageService
    {
        Task<HomePageContent> GetHomePageContentAsync();
        Task<List<EventCard>> GetUpcomingEventsAsync(int count = 3);
        Task<List<TestimonialCard>> GetTestimonialsAsync(int count = 3);
        Task<List<FeatureCard>> GetFeaturesAsync();
        Task SaveHomePageContentAsync(HomePageContent content);
    }
}