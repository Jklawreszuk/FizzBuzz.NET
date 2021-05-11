using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace FizzBuzzNET.Models
{
    
    public class FizzBuzzRecord
    {   
        public int ID { get; set; }
        [Required]
        public DateTime Time { get; set; }

        [Required,MaxLength(8)]
        public string Result { get; set; }
        [Required,Range(1,1000)]
        public int Number { get; set; }

        public string RecordUserId { get; set; }
        public virtual IdentityUser RecordUser {get;set;}
    }
}