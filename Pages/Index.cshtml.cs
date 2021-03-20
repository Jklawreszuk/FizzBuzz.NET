using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using FizzBuzzNET.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using Microsoft.AspNetCore.Http;

namespace FizzBuzzNET.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        
        [BindProperty(SupportsGet = true)]
        public FizzBuzz FizzBuzz { get; set; }
        public string Result { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }



        /* Note: Uznałem że nie ma potrzeby przesyłania danych metodą POST,ponieważ stworzony przeze mnie formularz nie zawiera danych wrażliwych */
        public void OnGet()
        { 
            if(ModelState.IsValid)
            {
                Result = FizzBuzz.GetAnswer();
                //Wynik ostatniego formularza zapisuje w formie krotki
                HttpContext.Session.SetString("RecentFizzBuzz",JsonConvert.SerializeObject((FizzBuzz.Number,Result,DateTime.Now)));
                
            }
        }
    }
}
