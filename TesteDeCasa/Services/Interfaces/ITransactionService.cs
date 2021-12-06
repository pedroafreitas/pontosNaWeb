
using System;
using System.Collections.Generic;
using System.Transactions;
using TesteDeCasa.Models;

namespace TesteDeCasa.Services.Interfaces
{
    public interface ITransactionService
    {

        IEnumerable<Transaction> GetAllTransactions();

        Response GetById(Guid id);

        bool AuthorizeOperation(Account FromAccount, Account ToAccount, decimal Amount, string TransactionPin, string OperationType = "default");
        Response MakeDeposit(String ToAccount, decimal Amount, string TransactionPin);

        Response MakeWithdrawal(string FromAccount, decimal Amount, string TransactionPin);

        Response MakeFundsTransfer(string FromAccount, string ToAccount, decimal Amount, string TransactionPin);

        Response ReversalFundsTransfer(Guid id, string TransactionPin);
    }
}