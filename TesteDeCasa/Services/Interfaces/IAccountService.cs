
using System;
using System.Collections.Generic;
using TesteDeCasa.Models;

namespace TesteDeCasa.Services.Interfaces
{
    public interface IAccountService
    {
        Account Authenticate(string AccountNumber, string Pin);

        IEnumerable<Account> GetAllAccounts();
        Account Create(Account account, string Pin, string ConfirmPin);

        void Update(Account account, string Pin = null);

        void Delete(Guid Id);

        Account GetById(Guid Id);

        Account GetByAccountNumber(string AccountNumber);
    }
}