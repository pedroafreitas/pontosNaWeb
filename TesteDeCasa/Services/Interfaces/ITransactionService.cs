
using System;
using System.Collections.Generic;
using System.Transactions;
using TesteDeCasa.Models;

namespace TesteDeCasa.Services.Interfaces
{
    public interface ITrasactionService
    {
        Response CreateNewTransaction(Transaction transaction);

        Response FindTransactionsByDate(DateTime date);

        Response MakeDeposit(string AccountNumber, string Amount, string TransactionPin);

        Response MakeWithDraw(string AccountNumber, string Amount, string TransactionPin);

        Response MakeFundsTransfer(string FromAccount, string ToAccount, decimal Amount);

        Response ReversalFundsTransfer(string TransactionPin);
    }
}