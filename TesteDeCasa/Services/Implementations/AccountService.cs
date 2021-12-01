using System;
using System.Collections.Generic;
using TesteDeCasa.Services.Interfaces;
using TesteDeCasa.DAL;
using TesteDeCasa.Models;
using System.Linq;
using System.Text;

namespace TesteDeCasa.Services.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly BankingDbContext _dbContext;

        public AccountService(BankingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Account Authenticate(string AccountNumber, string Pin)
        {
            var account = _dbContext.Accounts.Where(x => x.AccountNumberGenerated == AccountNumber).SingleOrDefault();
            if(account == null)
                return null;

            if(!VerifyPinHash(Pin, account.PinHash, account.PinSalt))
                return null;
        
            return account;
        }

        private static bool VerifyPinHash(string Pin, byte[] pinHash, byte[] pinSalt)
        {
            if(string.IsNullOrWhiteSpace(Pin)) throw new ArgumentNullException(Constants.ErrorNullPin);
            
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

        public Account Create(Account account, string Pin, string ConfirmPin)
        {

            if(_dbContext.Accounts.Any(x  => x.Email == account.Email)) throw new ApplicationException(Constants.ExistingAccount);

            if(_dbContext.Accounts.Any(x  => x.Cpf == account.Cpf)) throw new ApplicationException(Constants.ExistingAccount);

            if(!Pin.Equals(ConfirmPin)) throw new ArgumentException(Constants.WrongPassword);

            byte[] pinHash, pinSalt;

            CreatePinHash(Pin, out pinHash, out pinSalt);

            account.PinHash = pinHash;
            account.PinSalt = pinSalt;

            _dbContext.Accounts.Add(account);
            _dbContext.SaveChanges();

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

        public void Delete(Guid Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Account> GetAllAccounts()
        {
            throw new NotImplementedException();
        }

        public Account GetByAccountNumber(string AccountNumber)
        {
            throw new NotImplementedException();
        }

        public Account GetById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public void Update(Account account, string Pin = null)
        {
            throw new NotImplementedException();
        }
    }
}