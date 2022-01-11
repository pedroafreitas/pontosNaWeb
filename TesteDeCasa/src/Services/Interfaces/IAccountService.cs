
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteDeCasa.Models;

namespace TesteDeCasa.Services.Interfaces
{
    public interface IAccountService
    {
        Task<Account> AuthenticateAsync(string AccountNumber, string Pin);

        Task<IEnumerable<Account>> GetAllAccountsAsync();

        Task<Account> CreateAsync(Account account, string Pin, string ConfirmPin);

        Task UpdateAsync(Account account, string Pin = null);

        Task DeleteAsync(Guid Id);

        Task<Account> GetByIdAsync(Guid Id);

        Task<Account> GetByAccountNumberAsync(string AccountNumber);
    }
}