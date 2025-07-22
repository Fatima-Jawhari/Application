using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyApp1.Core.Entities;
using MyApp1.Core.Interfaces;

namespace MyApp1.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IHomePageService _homePageService;

        public IndexModel(ILogger<IndexModel> logger, IHomePageService homePageService)
        {
            _logger = logger;
            _homePageService = homePageService;
        }

        public HomePageContent Content { get; set; } = new();

        public async Task OnGetAsync()
        {
            Content = await _homePageService.GetHomePageContentAsync();
        }
    }
}
