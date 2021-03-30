using System;
using System.ComponentModel.DataAnnotations;

namespace FizzBuzzNET.Models
{
    public class FizzBuzz
    {
        public int ID { get; set; }
        
        [Required(ErrorMessage="Pole jest wymagane"),Range(1,1000, ErrorMessage = "Liczba musi być z przedziału 1-1000")]
        public int Number { get; set; }
        public string GetAnswer()
        {
            string result = (Number%3==0?"Fizz":"")+(Number%5==0?"Buzz":"");
            return result==string.Empty? $"{Number}":result;
        }
        
    }
}