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
        [RegularExpression(@"^[0-9]/d{6}", ErrorMessage = Constants.InvalidPin)]
        public string Pin {get; set; }
        public string ComfirmPin {get; set; }

        [Compare("Pin", ErrorMessage = Constants.WrongPassword)]
        public string ConfirmPin { get; set; }

    }
}