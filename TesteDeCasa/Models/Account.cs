using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteDeCasa.Models
{
    [Table("Accounts")]
    public record Account
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

        public byte[] PinHash {get; set; }

        public byte[] PinSalt {get; set; }

        public DateTime DateCreated {get; init;}

        public DateTime DateLastUpdated {get; set; }


        Random rand = new Random();
        public Account()
        {
            AccountNumberGenerated = Convert.ToString((long) rand.NextDouble() * 9_000_000_000L + 1_000_000_000L);
            AccountName = $"{FirstName} {LastName}";
        }
    }
    
    public enum AccountType
    {
        User, 
        Staff,
    }
}