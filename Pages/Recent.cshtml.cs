using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using FizzBuzzNET.Data;
using System.Linq;
using System.Collections.Generic;
using FizzBuzzNET.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace FizzBuzzNET.Pages
{
    [Authorize]
    public class RecentModel : PageModel
    {
        private readonly ILogger<RecentModel> _logger;
        private FizzBuzzContext _fizzBuzzContext;
        public List<FizzBuzzRecord> Records { get; set; }
        
        [BindProperty]
        public int rowID{get;set;}

        public RecentModel(ILogger<RecentModel> logger,FizzBuzzContext fizzBuzzContext)
        {
            _logger = logger;
            _fizzBuzzContext=fizzBuzzContext;
        }

        public void OnGet()
        {
            Records = _fizzBuzzContext.FizzBuzzRecords.OrderByDescending(f=>f.Time).Take(20).ToList();

        }
        public IActionResult OnPost()
        {
            var q = _fizzBuzzContext.FizzBuzzRecords.Where(n=>(n.ID==rowID) && (n.RecordUser.Id==User.FindFirstValue(ClaimTypes.NameIdentifier)));
            
            if(q.Count()>0)
            {
                
                _fizzBuzzContext.Remove(new FizzBuzzRecord(){ID=rowID});
                _fizzBuzzContext.SaveChanges();
            }
            
            return RedirectToPage();
        }
    }
}
