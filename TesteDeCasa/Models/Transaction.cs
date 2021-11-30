
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteDeCasa
{
    [Table("Transactions")]
    public class Transaction
    {
        [Key]
        public int Id {get; init; }

        public string TransactionUniqueReference {get; init; }

        public decimal TransactionAmount {get; init; }

        public TransactionStatus TransactionStatus {get; init; }

        public bool IsTransactionSuccessful => TransactionStatus.Equals(TransactionStatus.Success);

        public string TransactionSourceAccount {get; init; }

        public string TransactionDestinationAccount {get; init; }

        public string TransactionDescription {get; init; }

        public TransactionType TransactionType {get; init; }

        public DateTime TransactionDate {get; init; } 

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