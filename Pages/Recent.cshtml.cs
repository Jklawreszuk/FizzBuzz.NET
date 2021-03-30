using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using FizzBuzzNET.Data;
using System.Linq;
using System.Collections.Generic;
using FizzBuzzNET.Models;

namespace FizzBuzzNET.Pages
{
    public class RecentModel : PageModel
    {
        private readonly ILogger<RecentModel> _logger;
        private FizzBuzzContext _fizzBuzzContext;
        public List<FizzBuzzRecord> Records { get; set; }

        public RecentModel(ILogger<RecentModel> logger,FizzBuzzContext fizzBuzzContext)
        {
            _logger = logger;
            _fizzBuzzContext=fizzBuzzContext;
        }

        public void OnGet()
        {
            Records = _fizzBuzzContext.FizzBuzzRecords.ToList();
        }
    }
}
