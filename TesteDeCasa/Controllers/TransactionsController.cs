using System;
using System.Text.RegularExpressions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TesteDeCasa.Services.Interfaces;
using TesteDeCasa.Utils;

namespace TesteDeCasa.Controllers
{
    [ApiController]
    [Route("api/v3/[controller]")]
    public class TransactionsController : ControllerBase
    {
        private ITransactionService _transactionService;
        IMapper _mapper;
           
        public TransactionsController(ITransactionService transactionService, IMapper mapper)
        {
            _transactionService = transactionService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("get_all_transactions")]
        public IActionResult GetAllTransactions()
        {
            var transactions = _transactionService.GetAllTransactions();
            return Ok(transactions);
        }

        [HttpGet]
        [Route("get_transaction_by_id")]
        public IActionResult GetByTransactionId(Guid id)
        {
            if(!Regex.IsMatch(id.ToString(), Constants.RegexValidGuid)) return BadRequest();
            var transaction  = _transactionService.GetById(id);
            return Ok(transaction);
        }

        [HttpPost]
        [Route("make_deposit")]
        public IActionResult MakeDeposit(string AccountNumber, decimal Amount, string DepositantName)
        {
            if(!Regex.IsMatch(AccountNumber, Constants.RegexValidAccountNumber)) return BadRequest();
            return Ok(_transactionService.MakeDeposit(AccountNumber, Amount, DepositantName));
        }

        [HttpPost]
        [Route("make_withdrawal")]
        public IActionResult MakeWithdrawal(string AccountNumber, decimal Amount, string TransactionPin)
        {
            if(!Regex.IsMatch(AccountNumber, Constants.RegexValidAccountNumber)) return BadRequest();
            return Ok(_transactionService.MakeWithdrawal(AccountNumber, Amount, TransactionPin));
        }

        [HttpPost]
        [Route("make_founds_transfer")]
        public IActionResult MakeFoundsTransfer(string FromAccount, string ToAccount, decimal Amount, string TransactionPin)
        {
            if(!Regex.IsMatch(FromAccount, Constants.RegexValidAccountNumber) || !Regex.IsMatch(FromAccount, Constants.RegexValidAccountNumber)) return BadRequest();

            return Ok(_transactionService.MakeFundsTransfer(FromAccount, ToAccount, Amount, TransactionPin));
        }

        [HttpPost]
        [Route("make_reversal_founds_transfer")]
        public IActionResult ReversalFundsTransfer(Guid id, string TransactionPin)
        {
        //No recebimento de pagamento, o usuário ou lojista precisa receber notificação (envio de email, sms) enviada 
        //por um serviço de terceiro e eventualmente este serviço pode estar indisponível/instável. 
        //Use este mock para simular o envio (http://o4d9z.mocklab.io/notify). Melhor criar o mock https://www.mocklab.io/docs/mock-rest-api/
            if(!Regex.IsMatch(id.ToString(), Constants.RegexValidGuid)) return BadRequest();

            


            return Ok(_transactionService.ReversalFundsTransfer(id, TransactionPin));
        } 

        
        
    }
}