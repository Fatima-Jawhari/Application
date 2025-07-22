using System.ComponentModel.DataAnnotations;

namespace MyApp1.Core.Entities
{
    public class HeroContent
    {
        public string Title { get; set; } = string.Empty;
        public string Subtitle { get; set; } = string.Empty;
        public string CallToActionText { get; set; } = string.Empty;
        public string CallToActionLink { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string ImageAlt { get; set; } = string.Empty;
        public List<StatItem> Stats { get; set; } = new();
    }

    public class StatItem
    {
        public string Number { get; set; } = string.Empty;
        public string Label { get; set; } = string.Empty;
    }

    public class FeatureCard
    {
        public string Icon { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Link { get; set; } = string.Empty;
    }

    public class TestimonialCard
    {
        public string Text { get; set; } = string.Empty;
        public string AuthorName { get; set; } = string.Empty;
        public string AuthorClass { get; set; } = string.Empty;
        public string AuthorDepartment { get; set; } = string.Empty;
        public string AuthorImageUrl { get; set; } = string.Empty;
    }

    public class EventCard
    {
        public DateTime Date { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string RsvpLink { get; set; } = string.Empty;
    }

    public class SectionHeader
    {
        public string Title { get; set; } = string.Empty;
        public string Subtitle { get; set; } = string.Empty;
    }

    public class HomePageContent
    {
        public HeroContent Hero { get; set; } = new();
        public SectionHeader FeaturesSection { get; set; } = new();
        public List<FeatureCard> Features { get; set; } = new();
        public SectionHeader TestimonialsSection { get; set; } = new();
        public List<TestimonialCard> Testimonials { get; set; } = new();
        public SectionHeader EventsSection { get; set; } = new();
        public List<EventCard> Events { get; set; } = new();
        public SectionHeader WhyYouniSection { get; set; } = new();
    }
}