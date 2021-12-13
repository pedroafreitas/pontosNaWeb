using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
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
        private readonly ITransactionService _transactionService;
        private readonly IMapper _mapper;
           
        public TransactionsController(ITransactionService transactionService, IMapper mapper)
        {
            _transactionService = transactionService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("get_all_transactions")]
        public async Task<IActionResult> GetAllTransactionsAsync()
        {
            var transactions = await _transactionService.GetAllTransactionsAsync();
            return Ok(transactions);
        }

        [HttpGet]
        [Route("get_transaction_by_id")]
        public async Task<IActionResult> GetByTransactionIdAsync(Guid id)
        {
            if(!Regex.IsMatch(id.ToString(), Constants.RegexValidGuid)) return BadRequest();
            var transaction  = await _transactionService.GetByIdAsync(id);
            return Ok(transaction);
        }

        [HttpPost]
        [Route("make_deposit")]
        public async Task<IActionResult> MakeDepositAsync(string AccountNumber, decimal Amount, string DepositantName)
        {
            if(!Regex.IsMatch(AccountNumber, Constants.RegexValidAccountNumber)) return BadRequest();
            return Ok(await _transactionService.MakeDepositAsync(AccountNumber, Amount, DepositantName));
        }

        [HttpPost]
        [Route("make_withdrawal")]
        public async Task<IActionResult> MakeWithdrawalAsync(string AccountNumber, decimal Amount, string TransactionPin)
        {
            if(!Regex.IsMatch(AccountNumber, Constants.RegexValidAccountNumber)) return BadRequest();
            return Ok(await _transactionService.MakeWithdrawalAsync(AccountNumber, Amount, TransactionPin));
        }

        [HttpPost]
        [Route("make_founds_transfer")]
        public async Task<IActionResult> MakeFoundsTransferAsync(string FromAccount, string ToAccount, decimal Amount, string TransactionPin)
        {
            if(!Regex.IsMatch(FromAccount, Constants.RegexValidAccountNumber) || !Regex.IsMatch(FromAccount, Constants.RegexValidAccountNumber)) return BadRequest();

            return Ok(await _transactionService.MakeFundsTransferAsync(FromAccount, ToAccount, Amount, TransactionPin));
        }

        [HttpPost]
        [Route("make_reversal_founds_transfer")]
        public async Task<IActionResult> ReversalFundsTransferAsync(Guid id, string TransactionPin)
        {
            if(!Regex.IsMatch(id.ToString(), Constants.RegexValidGuid)) return BadRequest();

            return Ok(await _transactionService.ReversalFundsTransferAsync(id, TransactionPin));
        }        
    }
}