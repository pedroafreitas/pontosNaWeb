using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
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
        private BankingDbContext _dbContext;
        ILogger<TransactionService> _logger;
        
        private AppSettings _settings;
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

        public IEnumerable<Transaction> GetAllTransactions()
        {
            return _dbContext.Transactions.ToList();
        }
        public Response GetById(Guid id)
        {

            Response response = new();
            var transaction = _dbContext.Transactions.Where(x => x.Id == id).ToList();
            response.ResponseCode = "00";
            response.ResponseMessage = Constants.SuccessfulTransactionFound;
            response.Data = transaction; 

            return response;           
        }

        //Default: Transaction
        //Op 1: Deposit
        //Op 1: WithDrawal
        public bool AuthorizeOperation(Account FromAccount, Account ToAccount, decimal Amount, string TransactionPin, string OperationType = "default")
        {
            //contas iguais**
            Account authUser;

            if(Amount <= 0) throw new ApplicationException(Constants.InvalidValue);
            if(FromAccount.CurrentAccountBalance < Amount) throw new ApplicationException(Constants.InsufficienFunds);
            if(FromAccount.Id == ToAccount.Id) throw new ApplicationException(Constants.SameAccount);
            if((((int)FromAccount.AccountType) == 1)) throw new ApplicationException(Constants.InvalidUser);

            switch (OperationType)
            {
                case "Deposit":
                    if(ToAccount == null) throw new ApplicationException(Constants.NullAccount);
                    break;
                case "Withdrawal":
                    if(FromAccount == null) throw new ApplicationException(Constants.NullAccount);
                    
                    authUser =  _accountService.Authenticate(ToAccount.AccountNumberGenerated, TransactionPin);
                    if(authUser == null) throw new ApplicationException(Constants.InvalidPin);
                    break;
                default:
                    if(ToAccount == null || FromAccount == null) throw new ApplicationException(Constants.NullAccount);

                    authUser =  _accountService.Authenticate(FromAccount.AccountNumberGenerated, TransactionPin);
                    if(authUser == null) throw new ApplicationException(Constants.InvalidPin);
                    break;
            }       
            return true;       
        }

        public Response MakeTransaction(Account FromAccount, Account ToAccount, decimal Amount, Response response, Transaction transaction)
        {
            FromAccount.CurrentAccountBalance -= Amount;
            ToAccount.CurrentAccountBalance += Amount;

            if((_dbContext.Entry(FromAccount).State == Microsoft.EntityFrameworkCore.EntityState.Modified) &&
            (_dbContext.Entry(ToAccount).State == Microsoft.EntityFrameworkCore.EntityState.Modified))
            {
                transaction.TransactionStatus = TransactionStatus.Success;
                response.ResponseCode = "00";
                response.ResponseMessage = "Transaction successful";
                response.Data = null;
            }
            else
            {
                transaction.TransactionStatus = TransactionStatus.Failed;
                response.ResponseCode = "01";
                response.ResponseMessage = "Transaction failed";
                response.Data = null;
            }

            return response;
        }
        
        public void SetupTransaction(Transaction transaction, string FromAccount, string ToAccount, decimal Amount, TransactionType type)
        {
            transaction.TransactionType = type;
            transaction.TransactionSourceAccount = FromAccount;
            transaction.TransactionDestinationAccount = ToAccount;
            transaction.TransactionAmount = Amount;
            transaction.TransactionDate = DateTime.Now;
            transaction.TransactionDescription = $"Nova transação de  => {JsonConvert.SerializeObject(transaction.TransactionSourceAccount)} para => {JsonConvert.SerializeObject (transaction.TransactionDestinationAccount)} em => {transaction.TransactionDate} QUANTIDADE => {JsonConvert.SerializeObject(transaction.TransactionAmount)} TIPO => {transaction.TransactionType} STATUS => {transaction.TransactionStatus}";
        }

        public Response MakeDeposit(string ToAccount, decimal Amount, string DepositantName)
        {
            
            Account destinyAccount;
            Response response = new();
            Transaction transaction = new();
            const string operationType = "Deposit";

            try
            {
                destinyAccount = _accountService.GetByAccountNumber(ToAccount);

                if(AuthorizeOperation(null, destinyAccount, Amount, null, operationType))
                    MakeTransaction(null, destinyAccount, Amount, response, transaction);
            }
            catch (Exception ex)
            {
                _logger.LogError($"ERROR => {ex.Message}");
            }

            SetupTransaction(transaction, $"{operationType} (name: {DepositantName}", ToAccount, Amount, TransactionType.Deposit);
            
            _dbContext.Transactions.Add(transaction);
            _dbContext.SaveChanges();

            return response;
        }

         public Response MakeWithdrawal(string FromAccount, decimal Amount, string TransactionPin) 
        {
            //Validar se usuario tem saldo antes de sacar
            Account sourceAccount;
            Response response = new();
            Transaction transaction = new();
            const string operationType = "Withdrawal";
            
            try
            {
                sourceAccount = _accountService.GetByAccountNumber(FromAccount);
            
                if(AuthorizeOperation(sourceAccount, null, Amount, TransactionPin, operationType))
                    MakeTransaction(sourceAccount, null, Amount, response, transaction);
                
               
            }
            catch (Exception ex)
            {
                _logger.LogError($"ERROR => {ex.Message}");
            }

            
            SetupTransaction(transaction, FromAccount, operationType, Amount, TransactionType.Withdrawl);
            
            _dbContext.Transactions.Add(transaction);
            _dbContext.SaveChanges();

            return response;
        }

        public Response MakeFundsTransfer(string FromAccount, string ToAccount, decimal Amount, string TransactionPin)
        {            
            //talvez no controller - No recebimento de pagamento, o usuário ou lojista precisa receber notificação (envio de email, sms) enviada por um serviço de terceiro e eventualmente este serviço pode estar indisponível/instável. 
            //Use este mock para simular o envio (http://o4d9z.mocklab.io/notify). Melhor criar o mock https://www.mocklab.io/docs/mock-rest-api/

            Account sourceAccount;
            Account destinyAccount;
            Response response = new();
            Transaction transaction = new();
            
            try
            {
                sourceAccount = _accountService.GetByAccountNumber(_bankSettlementAccount);
                destinyAccount = _accountService.GetByAccountNumber(ToAccount);
            
                if(AuthorizeOperation(sourceAccount, destinyAccount, Amount, TransactionPin))
                    MakeTransaction(sourceAccount, destinyAccount, Amount, response, transaction);
            }
            catch (Exception ex)
            {
                _logger.LogError($"ERROR => {ex.Message}");
            }

            SetupTransaction(transaction, FromAccount, ToAccount, Amount, TransactionType.Transfer);
            
            _dbContext.Transactions.Add(transaction);
            _dbContext.SaveChanges();

            return response;
        }

        public Response ReversalFundsTransfer(Guid id, string TransactionPin)
        {
            //- A operação de transferência deve ser uma transação (ou seja, revertida em qualquer caso de inconsistência) e o dinheiro deve voltar para a carteira do usuário que envia. 
            Account destinyAccount;
            Response response = new();
            Transaction transaction = new();

            try
            {
                if(id == null) throw new ApplicationException(Constants.NullId);
            
                transaction = _dbContext.Transactions.Where(x => x.Id == id).SingleOrDefault();

                if(transaction == null) throw new ApplicationException(Constants.InvalidAccountNumber);

                destinyAccount = _accountService.GetByAccountNumber(transaction.TransactionDestinationAccount);

                response = MakeFundsTransfer(transaction.TransactionDestinationAccount, transaction.TransactionSourceAccount, transaction.TransactionAmount, TransactionPin);

            }
            catch (Exception ex)
            {
                _logger.LogError($"ERROR => {ex.Message}");
            }
            return response;
        }
    
    }
}