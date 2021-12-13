
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Transactions;
using TesteDeCasa.Models;

namespace TesteDeCasa.Services.Interfaces
{
    public interface ITransactionService
    {

        Task<IEnumerable<Transaction>> GetAllTransactionsAsync();

        Task<Response> GetByIdAsync(Guid id);

        Task<bool> AuthorizeOperationAsync(Account FromAccount, Account ToAccount, decimal Amount, string TransactionPin, string OperationType = "default");

        Task<Response> MakeDepositAsync(String ToAccount, decimal Amount, string TransactionPin);

        Task<Response> MakeWithdrawalAsync(string FromAccount, decimal Amount, string TransactionPin);

        Task<Response> MakeFundsTransferAsync(string FromAccount, string ToAccount, decimal Amount, string TransactionPin);

        Task<Response> ReversalFundsTransferAsync(Guid id, string TransactionPin);
    }
}