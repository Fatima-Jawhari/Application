using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyApp1.Core.Entities;
using MyApp1.Core.Interfaces;

namespace MyApp1.Web.Pages.Admin
{
    public class HomeContentModel : PageModel
    {
        private readonly IHomePageService _homePageService;

        public HomeContentModel(IHomePageService homePageService)
        {
            _homePageService = homePageService;
        }

        [BindProperty]
        public HomePageContent Content { get; set; } = new();

        public async Task OnGetAsync()
        {
            Content = await _homePageService.GetHomePageContentAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                await _homePageService.SaveHomePageContentAsync(Content);
                TempData["SuccessMessage"] = "Content updated successfully!";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error saving content: {ex.Message}";
            }
            
            return RedirectToPage();
        }
    }
}