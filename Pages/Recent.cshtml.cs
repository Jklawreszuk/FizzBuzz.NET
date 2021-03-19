using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace FizzBuzz.NET.Pages
{
    public class RecentModel : PageModel
    {
        private readonly ILogger<RecentModel> _logger;

        public RecentModel(ILogger<RecentModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            
        }
    }
}
