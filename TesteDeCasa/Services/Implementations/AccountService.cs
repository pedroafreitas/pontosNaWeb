using System;
using System.Collections.Generic;
using TesteDeCasa.Services.Interfaces;
using TesteDeCasa.DAL;
using TesteDeCasa.Models;
using System.Linq;
using System.Text;
using TesteDeCasa.Services.Strategy;

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

        public Account Create(Account account, string Pin, string ConfirmPin)
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

            _dbContext.Accounts.Add(account);
            _dbContext.SaveChanges();

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

        public void Delete(Guid Id)
        {
            var account = _dbContext.Accounts.Find(Id);
            if(account != null)
            {
                _dbContext.Accounts.Remove(account);
                _dbContext.SaveChanges(); 
            }
        }

        public IEnumerable<Account> GetAllAccounts()
        {
            return _dbContext.Accounts.ToList();
        }

        public Account GetByAccountNumber(string AccountNumber)
        {
            var account = _dbContext.Accounts.Where(x => x.AccountNumberGenerated == AccountNumber).FirstOrDefault();
            if(account == null) return null;

            return account;
        }

        public Account GetById(Guid Id)
        {
            var account = _dbContext.Accounts.Where(x => x.Id.Equals(Id)).FirstOrDefault();
            if(account == null) return null;

            return account;
        }

        //The user can only update his/her Email, Pin and LastName
        public void Update(Account account, string Pin = null)
        {
            var accountToBeUpdated = _dbContext.Accounts.Where(x => x.Id == account.Id).SingleOrDefault();

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
            _dbContext.SaveChanges();
        }
    }
}