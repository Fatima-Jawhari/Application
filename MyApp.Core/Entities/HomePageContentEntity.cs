using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyApp1.Core.Entities
{
    [Table("HomePageContents")]
    public class HomePageContentEntity
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(200)]
        public string HeroTitle { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(1000)]
        public string HeroSubtitle { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(50)]
        public string HeroCallToActionText { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(500)]
        public string HeroCallToActionLink { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(500)]
        public string HeroImageUrl { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(200)]
        public string HeroImageAlt { get; set; } = string.Empty;
        
        // Features Section
        [Required]
        [MaxLength(200)]
        public string FeaturesSectionTitle { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(1000)]
        public string FeaturesSectionSubtitle { get; set; } = string.Empty;
        
        // Testimonials Section
        [Required]
        [MaxLength(200)]
        public string TestimonialsSectionTitle { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(1000)]
        public string TestimonialsSectionSubtitle { get; set; } = string.Empty;
        
        // Events Section
        [Required]
        [MaxLength(200)]
        public string EventsSectionTitle { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(1000)]
        public string EventsSectionSubtitle { get; set; } = string.Empty;
        
        // Why Youni Section
        [Required]
        [MaxLength(200)]
        public string WhyYouniSectionTitle { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(1000)]
        public string WhyYouniSectionSubtitle { get; set; } = string.Empty;
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        
        // Navigation properties
        public virtual ICollection<StatItemEntity> Stats { get; set; } = new List<StatItemEntity>();
        public virtual ICollection<FeatureCardEntity> Features { get; set; } = new List<FeatureCardEntity>();
        public virtual ICollection<TestimonialCardEntity> Testimonials { get; set; } = new List<TestimonialCardEntity>();
        public virtual ICollection<EventCardEntity> Events { get; set; } = new List<EventCardEntity>();
    }

    [Table("StatItems")]
    public class StatItemEntity
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public int HomePageContentId { get; set; }
        
        [Required]
        [MaxLength(20)]
        public string Number { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(100)]
        public string Label { get; set; } = string.Empty;
        
        public int Order { get; set; }
        
        [ForeignKey(nameof(HomePageContentId))]
        public virtual HomePageContentEntity HomePageContent { get; set; } = null!;
    }

    [Table("FeatureCards")]
    public class FeatureCardEntity
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public int HomePageContentId { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Icon { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(500)]
        public string Link { get; set; } = string.Empty;
        
        public int Order { get; set; }
        
        [ForeignKey(nameof(HomePageContentId))]
        public virtual HomePageContentEntity HomePageContent { get; set; } = null!;
    }

    [Table("TestimonialCards")]
    public class TestimonialCardEntity
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public int HomePageContentId { get; set; }
        
        [Required]
        [MaxLength(1000)]
        public string Text { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(200)]
        public string AuthorName { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(100)]
        public string AuthorClass { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(100)]
        public string AuthorDepartment { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(500)]
        public string AuthorImageUrl { get; set; } = string.Empty;
        
        public int Order { get; set; }
        
        [ForeignKey(nameof(HomePageContentId))]
        public virtual HomePageContentEntity HomePageContent { get; set; } = null!;
    }

    [Table("EventCards")]
    public class EventCardEntity
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public int HomePageContentId { get; set; }
        
        [Required]
        public DateTime Date { get; set; }
        
        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(1000)]
        public string Description { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(200)]
        public string Location { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(500)]
        public string ImageUrl { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(500)]
        public string RsvpLink { get; set; } = string.Empty;
        
        public int Order { get; set; }
        
        [ForeignKey(nameof(HomePageContentId))]
        public virtual HomePageContentEntity HomePageContent { get; set; } = null!;
    }
}