using System;
using System.Collections.Generic;
using TesteDeCasa.Services.Interfaces;
using TesteDeCasa.DAL;
using TesteDeCasa.Models;
using System.Linq;
using System.Text;
using TesteDeCasa.Services.Strategy;
using TesteDeCasa.Utils;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TesteDeCasa.Services.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly BankingDbContext _dbContext;
        
        public AccountService(BankingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Account> AuthenticateAsync(string AccountNumber, string Pin)
        {
            var account = await _dbContext.Accounts.Where(x => x.AccountNumberGenerated == AccountNumber).SingleOrDefaultAsync();
            if(account == null)
                return null;

            if(!VerifyPinHash(Pin, account.PinHash, account.PinSalt))
                return null;
        
            return account;
        }

        private static bool VerifyPinHash(string Pin, byte[] pinHash, byte[] pinSalt)
        {
            if(string.IsNullOrWhiteSpace(Pin)) throw new ArgumentNullException(Constants.InvalidPin);
            
            using(var hmac = new System.Security.Cryptography.HMACSHA512(pinSalt))
            {
                var computedPinHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(Pin));
                for(int i = 0; i < computedPinHash.Length; i++)
                {
                    if(computedPinHash[i] != pinHash[i]) return false;
                }
            }
            return true;
        }

        public async Task<Account> CreateAsync(Account account, string Pin, string ConfirmPin)
        {
            CpfCnpj _cpfCnpj = new();
            
            if(_dbContext.Accounts.Any(x  => x.Email == account.Email)) throw new ApplicationException(Constants.ExistingAccountEmail);

            if(_dbContext.Accounts.Any(x  => x.Cpf == account.Cpf)) throw new ApplicationException(Constants.ExistingAccountCpf);

            if(!Pin.Equals(ConfirmPin)) throw new ArgumentException(Constants.WrongPassword);

            if(!_cpfCnpj.IsValidCpfCnpj(account.Cpf)) throw new ArgumentException(Constants.InvalidCpfCnpj);
            
            
            byte[] pinHash, pinSalt;

            CreatePinHash(Pin, out pinHash, out pinSalt);

            account.PinHash = pinHash;
            account.PinSalt = pinSalt;

            await _dbContext.Accounts.AddAsync(account);
            await _dbContext.SaveChangesAsync();

            _cpfCnpj = null;
            return account;
        }

        private static void CreatePinHash(string pin, out byte[] pinHash, out byte[] pinSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                pinSalt = hmac.Key;
                pinHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(pin));
            }
        }

        public async Task DeleteAsync(Guid Id)
        {
            var account = await _dbContext.Accounts.FindAsync(Id);
            if(account != null)
            {
                _dbContext.Accounts.Remove(account);
                await _dbContext.SaveChangesAsync(); 
            }
        }

        public async Task<IEnumerable<Account>> GetAllAccountsAsync()
        {
            return await _dbContext.Accounts.ToListAsync();
        }

        public async Task<Account> GetByAccountNumberAsync(string AccountNumber)
        {
            var account = _dbContext.Accounts.Where(x => x.AccountNumberGenerated == AccountNumber).FirstOrDefaultAsync();
            if(account == null) throw new ApplicationException(Constants.NullAccount);

            return await account;
        }

        public async Task<Account> GetByIdAsync(Guid Id)
        {
            var account = _dbContext.Accounts.Where(x => x.Id.Equals(Id)).FirstOrDefaultAsync();
            if(account == null) throw new ApplicationException(Constants.NullAccount);

            return await account;
        }

        //The user can only update his/her Email, Pin and LastName
        public async Task UpdateAsync(Account account, string Pin = null)
        {
            var accountToBeUpdated = await _dbContext.Accounts.Where(x => x.Id == account.Id).SingleOrDefaultAsync();

            if(accountToBeUpdated == null) throw new ApplicationException(Constants.NullAccount);

            if(!string.IsNullOrWhiteSpace(account.Email))
            {
                if(_dbContext.Accounts.Any(x => x.Email == account.Email)) throw new ApplicationException(Constants.ExistingAccountEmail);
                accountToBeUpdated.Email = account.Email;
            }

            if(!string.IsNullOrWhiteSpace(Pin))
            {
                byte[] pinHash, pinSalt;
                CreatePinHash(Pin, out pinHash, out pinSalt);

                accountToBeUpdated.PinHash = pinHash;
                accountToBeUpdated.PinSalt = pinSalt;
            }

            if(!string.IsNullOrWhiteSpace(account.LastName))
            {
                accountToBeUpdated.LastName = account.LastName;                
            }
            accountToBeUpdated.DateLastUpdated = DateTime.Now;

            _dbContext.Accounts.Update(accountToBeUpdated);
            await _dbContext.SaveChangesAsync();
        }
    }
}