using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace FizzBuzzNET.Pages
{
    public class LastSessionModel : PageModel
    {
        private readonly ILogger<LastSessionModel> _logger;

        public LastSessionModel(ILogger<LastSessionModel> logger)
        {
            _logger = logger;
        }
    }
}
