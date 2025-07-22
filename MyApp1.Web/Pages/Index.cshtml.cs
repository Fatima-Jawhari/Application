using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyApp1.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        // Dynamic Footer Properties
        public FooterData Footer { get; set; } = new FooterData();

        public void OnGet()
        {
            // Initialize dynamic footer data
            Footer = new FooterData
            {
                CompanyName = "Youni",
                Description = "Connecting alumni worldwide through innovation and community.",
                CopyrightYear = DateTime.Now.Year,
                ContactInfo = new ContactInfo
                {
                    Email = "contact@youni.com",
                    Phone = "+1 (555) 123-4567",
                    Address = "123 University Ave, Alumni City, AC 12345"
                },
                QuickLinks = new List<FooterLink>
                {
                    new FooterLink { Title = "About Us", Url = "/about" },
                    new FooterLink { Title = "Features", Url = "#features" },
                    new FooterLink { Title = "Events", Url = "#network" },
                    new FooterLink { Title = "Contact", Url = "/contact" }
                },
                SupportLinks = new List<FooterLink>
                {
                    new FooterLink { Title = "Help Center", Url = "/help" },
                    new FooterLink { Title = "Privacy Policy", Url = "/privacy" },
                    new FooterLink { Title = "Terms of Service", Url = "/terms" },
                    new FooterLink { Title = "FAQ", Url = "/faq" }
                },
                SocialLinks = new List<SocialLink>
                {
                    new SocialLink { Platform = "Facebook", Url = "https://facebook.com/youni", Icon = "fab fa-facebook-f" },
                    new SocialLink { Platform = "Twitter", Url = "https://twitter.com/youni", Icon = "fab fa-twitter" },
                    new SocialLink { Platform = "LinkedIn", Url = "https://linkedin.com/company/youni", Icon = "fab fa-linkedin-in" },
                    new SocialLink { Platform = "Instagram", Url = "https://instagram.com/youni", Icon = "fab fa-instagram" }
                },
                Statistics = new List<StatisticItem>
                {
                    new StatisticItem { Value = "10K+", Label = "Alumni Connected" },
                    new StatisticItem { Value = "500+", Label = "Events Yearly" },
                    new StatisticItem { Value = "100+", Label = "Career Opportunities" },
                    new StatisticItem { Value = "50+", Label = "Universities" }
                }
            };
        }
    }

    // Footer Data Models
    public class FooterData
    {
        public string CompanyName { get; set; } = "";
        public string Description { get; set; } = "";
        public int CopyrightYear { get; set; }
        public ContactInfo ContactInfo { get; set; } = new ContactInfo();
        public List<FooterLink> QuickLinks { get; set; } = new List<FooterLink>();
        public List<FooterLink> SupportLinks { get; set; } = new List<FooterLink>();
        public List<SocialLink> SocialLinks { get; set; } = new List<SocialLink>();
        public List<StatisticItem> Statistics { get; set; } = new List<StatisticItem>();
    }

    public class ContactInfo
    {
        public string Email { get; set; } = "";
        public string Phone { get; set; } = "";
        public string Address { get; set; } = "";
    }

    public class FooterLink
    {
        public string Title { get; set; } = "";
        public string Url { get; set; } = "";
    }

    public class SocialLink
    {
        public string Platform { get; set; } = "";
        public string Url { get; set; } = "";
        public string Icon { get; set; } = "";
    }

    public class StatisticItem
    {
        public string Value { get; set; } = "";
        public string Label { get; set; } = "";
    }
}
