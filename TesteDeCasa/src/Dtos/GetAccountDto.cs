using System;
using System.ComponentModel.DataAnnotations;
using TesteDeCasa.Models;

namespace TesteDeCasa.Dtos
{
    public class GetAccountDto
    {
        [Key]
        public Guid Id {get; init; }

        public string Cpf {get; init; }

        public string FirstName {get; init; }

        public string LastName {get; set; }

        public string AccountName {get; init; }

        public string Email {get; set;}

        public decimal CurrentAccountBalance {get; set; }

        public AccountType AccountType {get; init; }

        public string AccountNumberGenerated {get; init; }

        public DateTime DateCreated {get; init;}

        public DateTime DateLastUpdated {get; set; }        
    }
}