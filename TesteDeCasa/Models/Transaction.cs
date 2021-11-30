
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

        public string TransactionDestinyAccount {get; init; }
    }
}