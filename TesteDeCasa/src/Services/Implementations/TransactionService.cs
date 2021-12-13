using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using TesteDeCasa;
using TesteDeCasa.DAL;
using TesteDeCasa.Models;
using TesteDeCasa.Services.Interfaces;
using TesteDeCasa.Utils;

namespace TesteDeCada.Services.Implementations
{
    public class TransactionService : ITransactionService
    {
        private readonly BankingDbContext _dbContext;
        private readonly ILogger<TransactionService> _logger;
        
        private readonly AppSettings _settings;
        private static string _bankSettlementAccount;
        private readonly IAccountService _accountService;

        public TransactionService (BankingDbContext dbContext, ILogger<TransactionService> logger, IOptions<AppSettings> settings, IAccountService accountService)
        {
            _dbContext = dbContext;
            _logger = logger;
            _settings = settings.Value;
            _bankSettlementAccount = _settings.BankSettlementAccount;
            _accountService = accountService;
        }

        public async Task<IEnumerable<Transaction>> GetAllTransactionsAsync()
        {
            return await _dbContext.Transactions.ToListAsync();
        }
        
        public async Task<Response> GetByIdAsync(Guid id)
        {

            Response response = new();
            var transaction = await _dbContext.Transactions.Where(x => x.Id == id).ToListAsync();
            response.ResponseCode = "00";
            response.ResponseMessage = Constants.SuccessfulTransactionFound;
            response.Data = transaction; 

            return response;           
        }

        //Default: Transaction
        //Op 1: Deposit
        //Op 1: WithDrawal
        public async Task<bool> AuthorizeOperationAsync(Account FromAccount, Account ToAccount, decimal Amount, string TransactionPin, string OperationType = "default")
        {
            //contas iguais**
            Account authUser;
            if(Amount <= 0) throw new ApplicationException(Constants.InvalidValue);

            switch (OperationType)
            {
                case "Deposit":
                    if(ToAccount == null) throw new ApplicationException(Constants.NullAccount);
                    break;
                case "Withdrawal":
                    if(FromAccount == null) throw new ApplicationException(Constants.NullAccount);
                    if((((int)FromAccount.AccountType) == 1)) throw new ApplicationException(Constants.InvalidUser);
                    if(FromAccount.CurrentAccountBalance < Amount) throw new ApplicationException(Constants.InsufficienFunds);
                    
                    authUser = await _accountService.AuthenticateAsync(FromAccount.AccountNumberGenerated, TransactionPin);
                    if(authUser == null) throw new ApplicationException(Constants.InvalidPin);
                    break;
                default:
                    if((((int)FromAccount.AccountType) == 1)) throw new ApplicationException(Constants.InvalidUser);
                    if(FromAccount.Id == ToAccount.Id) throw new ApplicationException(Constants.SameAccount);
                    if(FromAccount.CurrentAccountBalance < Amount) throw new ApplicationException(Constants.InsufficienFunds);
                    if(ToAccount == null || FromAccount == null) throw new ApplicationException(Constants.NullAccount);

                    authUser = await _accountService.AuthenticateAsync(FromAccount.AccountNumberGenerated, TransactionPin);
                    if(authUser == null) throw new ApplicationException(Constants.InvalidPin);
                    break;
            }       
            return true;       
        }
        
        public void SetupTransaction(Transaction transaction, string FromAccount, string ToAccount, decimal Amount, TransactionType type)
        {
            transaction.TransactionType = type;
            transaction.TransactionSourceAccount = FromAccount;
            transaction.TransactionDestinationAccount = ToAccount;
            transaction.TransactionAmount = Amount;
            transaction.TransactionDate = DateTime.Now;
            transaction.TransactionDescription = $"Nova transação de  => {JsonConvert.SerializeObject(transaction.TransactionSourceAccount)} " +
                                                    $"para => {JsonConvert.SerializeObject (transaction.TransactionDestinationAccount)} " +
                                                    $"em => {transaction.TransactionDate} " +
                                                    $"QUANTIDADE => {JsonConvert.SerializeObject(transaction.TransactionAmount)} " +
                                                    $"TIPO => {transaction.TransactionType} " +
                                                    $"STATUS => {transaction.TransactionStatus}";
        }
        
        public async Task<Response> MakeDepositAsync(string ToAccount, decimal Amount, string DepositantName)
        {
            
            Account destinyAccount;
            Response response = new();
            Transaction transaction = new();
            const string operationType = "Deposit";

            try
            {
                destinyAccount = await _accountService.GetByAccountNumberAsync(ToAccount);

                if(await AuthorizeOperationAsync(null, destinyAccount, Amount, null, operationType))
                {
                    destinyAccount.CurrentAccountBalance += Amount;

                    if(_dbContext.Entry(destinyAccount).State == Microsoft.EntityFrameworkCore.EntityState.Modified)
                    {
                        transaction.TransactionStatus = TransactionStatus.Success;
                        response.ResponseCode = "00";
                        response.ResponseMessage = Constants.TransactionSuccessful;
                        response.Data = null;
                    }
                    else
                    {
                        destinyAccount.CurrentAccountBalance -= Amount;
                        transaction.TransactionStatus = TransactionStatus.Failed;
                        response.ResponseCode = "01";
                        response.ResponseMessage = Constants.TransactionFailed;
                        response.Data = null;
                    }
                } 
            }
            catch (Exception ex)
            {
                transaction.TransactionStatus = TransactionStatus.Failed;
                response.ResponseCode = "01";
                response.ResponseMessage = Constants.TransactionFailed;
                _logger.LogError($"ERROR => {ex.Message}");
            }

            SetupTransaction(transaction, $"{operationType} (name: {DepositantName})", ToAccount, Amount, TransactionType.Deposit);
            
            await _dbContext.Transactions.AddAsync(transaction);
            await _dbContext.SaveChangesAsync();

            return response;
        }

        public async Task<Response> MakeWithdrawalAsync(string FromAccount, decimal Amount, string TransactionPin) 
        {
            //Validar se usuario tem saldo antes de sacar
            Account sourceAccount;
            Response response = new();
            Transaction transaction = new();
            const string operationType = "Withdrawal";
            
            try
            {
                sourceAccount = await _accountService.GetByAccountNumberAsync(FromAccount);
            
                if(await AuthorizeOperationAsync(sourceAccount, null, Amount, TransactionPin, operationType))
                {
                    sourceAccount.CurrentAccountBalance -= Amount;

                    if((_dbContext.Entry(sourceAccount).State == Microsoft.EntityFrameworkCore.EntityState.Modified))
                    {
                        transaction.TransactionStatus = TransactionStatus.Success;
                        response.ResponseCode = "00";
                        response.ResponseMessage = Constants.TransactionSuccessful;
                        response.Data = null;
                    }
                    else
                    {
                        transaction.TransactionStatus = TransactionStatus.Failed;
                        response.ResponseCode = "01";
                        response.ResponseMessage = Constants.TransactionFailed;
                        sourceAccount.CurrentAccountBalance += Amount;
                        response.Data = null;
                    }                    
                }
            }
            catch (Exception ex)
            {
                transaction.TransactionStatus = TransactionStatus.Failed;
                response.ResponseCode = "01";
                response.ResponseMessage = Constants.TransactionFailed;
                _logger.LogError($"ERROR => {ex.Message}");
            }

            
            SetupTransaction(transaction, FromAccount, operationType, Amount, TransactionType.Withdrawl);
            
            _dbContext.Transactions.Add(transaction);
            _dbContext.SaveChanges();

            return response;
        }

        public async Task<Response> MakeFundsTransferAsync(string FromAccount, string ToAccount, decimal Amount, string TransactionPin)
        {            
            Account sourceAccount;
            Account destinyAccount;
            Response response = new();
            Transaction transaction = new();
            
            try
            {
                sourceAccount = await _accountService.GetByAccountNumberAsync(FromAccount);
                destinyAccount = await _accountService.GetByAccountNumberAsync(ToAccount);
            
                if(await AuthorizeOperationAsync(sourceAccount, destinyAccount, Amount, TransactionPin))
                {
                    sourceAccount.CurrentAccountBalance -= Amount;
                    destinyAccount.CurrentAccountBalance += Amount;

                    if((_dbContext.Entry(sourceAccount).State == Microsoft.EntityFrameworkCore.EntityState.Modified) &&
                    (_dbContext.Entry(destinyAccount).State == Microsoft.EntityFrameworkCore.EntityState.Modified))
                    {
                        transaction.TransactionStatus = TransactionStatus.Success;
                        response.ResponseCode = "00";
                        response.ResponseMessage = Constants.TransactionSuccessful;
                        response.Data = null;
                    }
                    else
                    {
                        transaction.TransactionStatus = TransactionStatus.Failed;
                        response.ResponseCode = "01";
                        response.ResponseMessage = Constants.TransactionFailed;
                        sourceAccount.CurrentAccountBalance += Amount;
                        destinyAccount.CurrentAccountBalance -= Amount;
                        response.Data = null;
                    }                    
                } 
            }
            catch (Exception ex)
            {
                transaction.TransactionStatus = TransactionStatus.Failed;
                response.ResponseCode = "01";
                response.ResponseMessage = Constants.TransactionFailed;
                _logger.LogError($"ERROR => {ex.Message}");
            }

            SetupTransaction(transaction, FromAccount, ToAccount, Amount, TransactionType.Transfer);
            
            await _dbContext.Transactions.AddAsync(transaction);
            await _dbContext.SaveChangesAsync();

            return response;
        }

        public async Task<Response> ReversalFundsTransferAsync(Guid id, string TransactionPin)
        {
            Account destinyAccount;
            Response response = new();
            Transaction transaction = new();

            try
            {           
                transaction = _dbContext.Transactions.Where(x => x.Id == id).SingleOrDefault();

                if(transaction == null) throw new ApplicationException(Constants.InvalidAccountNumber);
                if(transaction.TransactionType != TransactionType.Transfer) throw new ApplicationException(Constants.InvalidReversal);
                destinyAccount = await _accountService.GetByAccountNumberAsync(transaction.TransactionDestinationAccount);

                response = await MakeFundsTransferAsync(transaction.TransactionDestinationAccount, transaction.TransactionSourceAccount, transaction.TransactionAmount, TransactionPin);

            }
            catch (Exception ex)
            {
                _logger.LogError($"ERROR => {ex.Message}");
            }
            return response;
        }
    }
}