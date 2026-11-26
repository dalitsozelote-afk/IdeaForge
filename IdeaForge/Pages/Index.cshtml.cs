
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IdeaForge.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string Idea { get; set; } = "";

        public string Message { get; set; } = "";

        public void OnGet()
        {
        }

        public void OnPostSubmitIdea()
        {
            if (string.IsNullOrWhiteSpace(Idea))
            {
                Message = "Please describe your invention idea first.";
                return;
            }

            Message = "Your invention idea has been received!";
        }
    }
}
