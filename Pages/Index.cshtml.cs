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
        public string Result { get; set; }

        private string GiveAnswer(int number){
            string result = string.Empty;
            if (number %3==0 ){
                result += "fizz";
            }
            if (number %5==0){
                result += "buzz";
            }

            return (result == string.Empty ? $"{number}" : result);
        }
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }



        /* Note: Uznałem że nie ma potrzeby przesyłania danych metodą POST,ponieważ stworzony przeze mnie formularz nie zawiera danych wrażliwych */
        public void OnGet()
        { 
            if(ModelState.IsValid)
            {
                Result = GiveAnswer(FizzBuzz.Number); 
                
            }
        }
    }
}
