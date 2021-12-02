using System;
using TesteDeCasa;
using TesteDeCasa.Models;
using TesteDeCasa.Services.Interfaces;
namespace TesteDeCada.Services.Implementations
{
    public class TransactionService : ITrasactionService
    {
        public Response CreateNewTransaction(Transaction transaction)
        {
            throw new NotImplementedException();
        }

        public Response FindTransactionsByDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Response MakeDeposit(string AccountNumber, string Amount, string TransactionPin)
        {
            throw new NotImplementedException();
        }

        public Response MakeFundsTransfer(string FromAccount, string ToAccount, decimal Amount)
        {
            throw new NotImplementedException();
        }

        public Response MakeWithDraw(string AccountNumber, string Amount, string TransactionPin)
        {
            throw new NotImplementedException();
        }

        public Response ReversalFundsTransfer(string TransactionPin)
        {
            throw new NotImplementedException();
        }
    }
}