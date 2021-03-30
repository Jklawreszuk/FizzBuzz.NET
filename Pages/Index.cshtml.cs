using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using FizzBuzzNET.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using Microsoft.AspNetCore.Http;
using FizzBuzzNET.Data;

namespace FizzBuzzNET.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private FizzBuzzContext _fizzBuzzContext;
        
        [BindProperty(SupportsGet = true)]
        public FizzBuzz FizzBuzz { get; set; }
        public string Result { get; set; }

        public IndexModel(ILogger<IndexModel> logger,FizzBuzzContext fizzBuzzContext)
        {
            _logger = logger;
            _fizzBuzzContext=fizzBuzzContext;
        }
        public void OnPost()
        { 
            if(ModelState.IsValid)
            {
                Result = FizzBuzz.GetAnswer();
                //Wynik ostatniego formularza zapisuje w formie krotki
                HttpContext.Session.SetString("RecentFizzBuzz",JsonConvert.SerializeObject((FizzBuzz.Number,Result,DateTime.Now)));

                _fizzBuzzContext.Add(new FizzBuzzRecord(){Number=FizzBuzz.Number,Time=DateTime.Now,Result=FizzBuzz.GetAnswer()});
                _fizzBuzzContext.SaveChanges();
                
            }
        }
    }
}
