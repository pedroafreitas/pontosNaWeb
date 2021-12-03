
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteDeCasa
{
    [Table("Transactions")]
    public class Transaction
    {
        [Key]
        public Guid Id {get; init; }

        public string TransactionUniqueReference {get; init; }

        public decimal TransactionAmount {get; set; }

        public TransactionStatus TransactionStatus {get; set; }

        public bool IsTransactionSuccessful => TransactionStatus.Equals(TransactionStatus.Success);

        public string TransactionSourceAccount {get; set; }

        public string TransactionDestinationAccount {get; set; }

        public string TransactionDescription {get; set; }

        public TransactionType TransactionType {get; set; }

        public DateTime TransactionDate {get; set; } 

        public Transaction()
        {
            TransactionUniqueReference = $"{Guid.NewGuid().ToString().Replace("-","").Substring(1, 27)}";
        }

    }

    public enum TransactionStatus
    {
        Failed,
        Success,
        Error
    }

    public enum TransactionType
    {
        Deposit,
        Withdrawl,
        Transfer
    }
}