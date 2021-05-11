using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using FizzBuzzNET.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using FizzBuzzNET.Data;

namespace FizzBuzzNET.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private FizzBuzzContext _fizzBuzzContext;
        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _signInManager;
        
        [BindProperty(SupportsGet = true)]
        public FizzBuzz FizzBuzz { get; set; }
        public string Result { get; set; }

        public IndexModel(ILogger<IndexModel> logger,FizzBuzzContext fizzBuzzContext,UserManager<IdentityUser> userManager,SignInManager<IdentityUser> signInManager)
        {
            _logger = logger;
            _fizzBuzzContext=fizzBuzzContext;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public void OnPost()
        { 
            if(ModelState.IsValid)
            {
                Result = FizzBuzz.GetAnswer();
                //Wynik ostatniego formularza zapisuje w formie krotki
                HttpContext.Session.SetString("RecentFizzBuzz",JsonConvert.SerializeObject((FizzBuzz.Number,Result,DateTime.Now)));

                if(_signInManager.IsSignedIn(User)){
                    var fizzRec = new FizzBuzzRecord(){
                        Number=FizzBuzz.Number,Time=DateTime.Now,Result=FizzBuzz.GetAnswer(),
                        RecordUser =  _userManager.FindByNameAsync(User.Identity.Name).Result
                    
                    
                    };
                    _fizzBuzzContext.Add(fizzRec);

                
                    _fizzBuzzContext.SaveChanges();
                }
                
                
            }
        }
    }
}
