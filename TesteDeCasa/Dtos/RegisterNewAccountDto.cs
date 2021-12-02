using System;
using System.ComponentModel.DataAnnotations;
using TesteDeCasa.Models;

namespace TesteDeCasa.Dtos
{
    public class RegisterNewAccountDto
    {
        public string Cpf {get; init; }

        public string FirstName {get; init; }

        public string LastName {get; set; }

        public string Email {get; set;}

        public AccountType AccountType {get; init; }

        public DateTime DateCreated {get; init;}

        public DateTime DateLastUpdated {get; set; }

        [Required]
        [RegularExpression(@"^[0-9]{6}", ErrorMessage = Constants.InvalidPin)]
        public string Pin { get; set; }
        [Required]
        [Compare("Pin", ErrorMessage = "Pins do not match")]
        public string ConfirmPin { get; set; }

    }
}