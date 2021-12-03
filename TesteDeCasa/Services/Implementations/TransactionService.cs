using System;
using System.Linq;
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
        
        
        public Response CreateNewTransaction(Transaction transaction)
        {
            Response response = new();
            _dbContext.Transactions.Add(transaction);
            _dbContext.SaveChanges();
            response.ResponseCode = "00";
            response.ResponseMessage = "Transação criada com sucesso";
            response.Data = null;

            return response;
        }

        public Response FindTransactionsByDate(DateTime date)
        {
            Response response = new();
            var transaction = _dbContext.Transactions.Where(x => x.TransactionDate == date).ToList();
            response.ResponseCode = "00";
            response.ResponseMessage = "Transação achada com sucesso";
            response.Data = transaction; 

            return response;           
        }

        public Response MakeDeposit(string AccountNumber, decimal Amount, string TransactionPin)
        {
            Response response = new();
            Account sourceAccount;
            Account destinyAccount;
            Transaction transaction = new();

            var authUser = _accountService.Authenticate(AccountNumber, TransactionPin);
            if(authUser == null) throw new ApplicationException("Invalid credentials");

            try
            {
                sourceAccount = _accountService.GetByAccountNumber(_bankSettlementAccount);
                destinyAccount = _accountService.GetByAccountNumber(AccountNumber);

                sourceAccount.CurrentAccountBalance -= Amount;
                destinyAccount.CurrentAccountBalance += Amount;

                if((_dbContext.Entry(sourceAccount).State == Microsoft.EntityFrameworkCore.EntityState.Modified) &&
                   (_dbContext.Entry(destinyAccount).State == Microsoft.EntityFrameworkCore.EntityState.Modified))
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
            }
            catch (Exception ex)
            {
                _logger.LogError($"ERROR => {ex.Message}");
            }
        
            transaction.TransactionType = TransactionType.Deposit;
            transaction.TransactionSourceAccount = _bankSettlementAccount;
            transaction.TransactionDestinationAccount = AccountNumber;
            transaction.TransactionAmount = Amount;
            transaction.TransactionDate = DateTime.Now;
            transaction.TransactionDescription = $"Nova transação de  => {JsonConvert.SerializeObject(transaction.TransactionSourceAccount)} para => {JsonConvert.SerializeObject (transaction.TransactionDestinationAccount)} em => {transaction.TransactionDate} QUANTIDADE => {JsonConvert.SerializeObject(transaction.TransactionAmount)} TIPO => {transaction.TransactionType} STATUS => {transaction.TransactionStatus}";

            _dbContext.Transactions.Add(transaction);
            _dbContext.SaveChanges();

            return response;
        }

        public Response MakeFundsTransfer(string FromAccount, string ToAccount, decimal Amount, string TransactionPin)
        {
            //aqui mesmo: Lojistas só recebem transferências, não enviam dinheiro para ninguém.
            
            //aqui mesmo: validar se usuario tem saldo antes de transferir
            
            //talvez no controller - No recebimento de pagamento, o usuário ou lojista precisa receber notificação (envio de email, sms) enviada por um serviço de terceiro e eventualmente este serviço pode estar indisponível/instável. 
            //Use este mock para simular o envio (http://o4d9z.mocklab.io/notify). Melhor criar o mock https://www.mocklab.io/docs/mock-rest-api/

            Response response = new();
            Account sourceAccount;
            Account destinyAccount;
            Transaction transaction = new();

            var authUser = _accountService.Authenticate(FromAccount, TransactionPin);
            if(authUser == null) throw new ApplicationException("Invalid credentials");

            try
            {
                sourceAccount = _accountService.GetByAccountNumber(FromAccount);
                destinyAccount = _accountService.GetByAccountNumber(ToAccount);

                sourceAccount.CurrentAccountBalance -= Amount;
                destinyAccount.CurrentAccountBalance += Amount;

                if((_dbContext.Entry(sourceAccount).State == Microsoft.EntityFrameworkCore.EntityState.Modified) &&
                   (_dbContext.Entry(destinyAccount).State == Microsoft.EntityFrameworkCore.EntityState.Modified))
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
            }
            catch (Exception ex)
            {
                _logger.LogError($"ERROR => {ex.Message}");
            }
        
            transaction.TransactionType = TransactionType.Transfer;
            transaction.TransactionSourceAccount = FromAccount;
            transaction.TransactionDestinationAccount = ToAccount;
            transaction.TransactionAmount = Amount;
            transaction.TransactionDate = DateTime.Now;
            transaction.TransactionDescription = $"Nova transação de  => {JsonConvert.SerializeObject(transaction.TransactionSourceAccount)} para => {JsonConvert.SerializeObject (transaction.TransactionDestinationAccount)} em => {transaction.TransactionDate} QUANTIDADE => {JsonConvert.SerializeObject(transaction.TransactionAmount)} TIPO => {JsonConvert.SerializeObject(transaction.TransactionType)} STATUS => {JsonConvert.SerializeObject(transaction.TransactionStatus)}";

            _dbContext.Transactions.Add(transaction);
            _dbContext.SaveChanges();
            
            return response;
        }

        public Response MakeWithdrawal(string AccountNumber, decimal Amount, string TransactionPin) 
        {
            //Validar se usuario tem saldo antes de sacar
            Response response = new();
            Account sourceAccount;
            Account destinyAccount;
            Transaction transaction = new();

            var authUser = _accountService.Authenticate(AccountNumber, TransactionPin);
            if(authUser == null) throw new ApplicationException("Invalid credentials");

            try
            {
                sourceAccount = _accountService.GetByAccountNumber(AccountNumber);
                destinyAccount = _accountService.GetByAccountNumber(_bankSettlementAccount);

                sourceAccount.CurrentAccountBalance -= Amount;
                destinyAccount.CurrentAccountBalance += Amount;

                if((_dbContext.Entry(sourceAccount).State == Microsoft.EntityFrameworkCore.EntityState.Modified) &&
                   (_dbContext.Entry(destinyAccount).State == Microsoft.EntityFrameworkCore.EntityState.Modified))
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
            }
            catch (Exception ex)
            {
                _logger.LogError($"ERROR => {ex.Message}");
            }
        
            transaction.TransactionType = TransactionType.Withdrawl;
            transaction.TransactionSourceAccount = AccountNumber;
            transaction.TransactionDestinationAccount = _bankSettlementAccount;
            transaction.TransactionAmount = Amount;
            transaction.TransactionDate = DateTime.Now;
            transaction.TransactionDescription = $"Nova transação de  => {JsonConvert.SerializeObject(transaction.TransactionSourceAccount)} para => {JsonConvert.SerializeObject (transaction.TransactionDestinationAccount)} em => {transaction.TransactionDate} QUANTIDADE => {JsonConvert.SerializeObject(transaction.TransactionAmount)} TIPO => {JsonConvert.SerializeObject(transaction.TransactionType)} STATUS => {JsonConvert.SerializeObject(transaction.TransactionStatus)}";

            _dbContext.Transactions.Add(transaction);
            _dbContext.SaveChanges();
            
            return response;
        }

        public Response ReversalFundsTransfer(Guid Id)
        {
            //- A operação de transferência deve ser uma transação (ou seja, revertida em qualquer caso de inconsistência) e o dinheiro deve voltar para a carteira do usuário que envia. 
            throw new NotImplementedException();
        }
    }
}