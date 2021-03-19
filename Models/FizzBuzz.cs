using System.ComponentModel.DataAnnotations;

namespace FizzBuzzNET.Models
{
    public class FizzBuzz
    {
        
        [Required(),Range(1,1000, ErrorMessage = "Liczba musi być z przedziału 1-1000")]
        public int Number { get; set; }

        
    }
}