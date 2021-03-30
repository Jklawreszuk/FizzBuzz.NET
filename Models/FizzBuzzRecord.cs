using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace FizzBuzzNET.Models
{
    [Required]
    public class FizzBuzzRecord
    {   
        public int ID { get; set; }
        public DateTime Time { get; set; }

        [MaxLength(8)]
        public string Result { get; set; }
        [Range(1,1000)]
        public int Number { get; set; }
    }
}