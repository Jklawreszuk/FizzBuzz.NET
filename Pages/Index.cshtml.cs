using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using FizzBuzzNET.Models;
using Microsoft.AspNetCore.Mvc;

namespace FizzBuzzNET.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        
        [BindProperty(SupportsGet = true)]
        public FizzBuzz FizzBuzz { get; set; }


        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        { 

        }
    }
}
