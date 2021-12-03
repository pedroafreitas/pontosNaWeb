
using System;
using System.Collections.Generic;
using System.Transactions;
using TesteDeCasa.Models;

namespace TesteDeCasa.Services.Interfaces
{
    public interface ITransactionService
    {
        Response CreateNewTransaction(Transaction transaction);

        Response FindTransactionsByDate(DateTime date);

        Response MakeDeposit(string AccountNumber, decimal Amount, string TransactionPin);

        Response MakeWithdrawal(string AccountNumber, decimal Amount, string TransactionPin);

        Response MakeFundsTransfer(string FromAccount, string ToAccount, decimal Amount, string TransactionPin);

        Response ReversalFundsTransfer(Guid Id);
    }
}