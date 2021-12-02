using System;
using System.ComponentModel.DataAnnotations;

namespace TesteDeCasa.Dtos
{
    public class UpdateAccountDto
    {
        [Key]
        public Guid Id {get; init; }

        public string Email {get; set; }

        public string LastName {get; set; }

        [Required]
        [RegularExpression(@"^[0-9]{6}", ErrorMessage = Constants.InvalidPin)]
        public string Pin {get; set; }

        [Compare("Pin", ErrorMessage = Constants.WrongPassword)]
        public string ConfirmPin { get; set; }
        
        public DateTime DateLastUpdated {get; set; }
    }
}