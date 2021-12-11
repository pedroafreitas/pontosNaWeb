using System;
using System.ComponentModel.DataAnnotations;

namespace TesteDeCasa.Dtos
{
    public class GetTransactionDto
    {
        [Key]
        public Guid Id {get; init; }

        public decimal TransactionAmount {get; set; }

        public TransactionStatus TransactionStatus {get; set; }

        public bool IsTransactionSuccessful => TransactionStatus.Equals(TransactionStatus.Success);

        public string TransactionSourceAccount {get; set; }

        public string TransactionDestinationAccount {get; set; }

        public string TransactionDescription {get; set; }

        public TransactionType TransactionType {get; set; }

        public DateTime TransactionDate {get; set; } 
    }
}