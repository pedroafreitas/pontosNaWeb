using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteDeCasa.Models
{
    [Table("Accounts")]
    public record Account
    {
        [Key]
        public int Cpf {get; init;}

        public string FirstName {get; init; }

        public string LastName {get; init; }

        public string AccountName{get; init; }

        public string Email {get; init;}

        public decimal CurrentAccountBalance {get; set; }

        public AccountType AccountType {get; init; }

        public string AccountNumberGenerated {get; init; }

        public byte[] PinHash {get; init; }

        public byte[] PinSalt {get; init; }

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