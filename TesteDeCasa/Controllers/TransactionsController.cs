using System.Text.RegularExpressions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TesteDeCasa.Services.Interfaces;
using TestesDeCasa.Dtos;

namespace TesteDeCasa.Controllers
{
    [ApiController]
    [Route("api/v3[controller]")]
    public class TransactionsController : ControllerBase
    {

        private ITransactionService _transactionService;
        IMapper _mapper;

        public TransactionsController(ITransactionService transactionService, IMapper mapper)
        {
            _transactionService = transactionService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("create_new_transaction")]
        public IActionResult CreateNewTransaction([FromBody] TransactionRequestDto transactionRequest)
        {
            if(!ModelState.IsValid) return BadRequest(transactionRequest);

            var transaction = _mapper.Map<Transaction>(transactionRequest);
            return Ok(_transactionService.CreateNewTransaction(transaction));

        }

        [HttpPost]
        [Route("make_deposit")]
        public IActionResult MakeDeposit(string AccountNumber, decimal Amount, string TransactionPin)
        {
            if(!Regex.IsMatch(AccountNumber, @"^[0][1-9]\d{9}|^[1-9]\d{9}$")) return BadRequest();
            return Ok(_transactionService.MakeDeposit(AccountNumber, Amount, TransactionPin));
        }

        [HttpPost]
        [Route("make_withdrawal")]
        public IActionResult MakeWithdrawal(string AccountNumber, decimal Amount, string TransactionPin)
        {
            if(!Regex.IsMatch(AccountNumber, @"^[0][1-9]\d{9}|^[1-9]\d{9}$")) return BadRequest();
            return Ok(_transactionService.MakeWithdrawal(AccountNumber, Amount, TransactionPin));
        }

        [HttpPost]
        [Route("make_founds_transfer")]
        public IActionResult MakeFoundsTransfer(string FromAccount, string ToAccount, decimal Amount, string TransactionPin)
        {
            if(!Regex.IsMatch(FromAccount, @"^[0][1-9]\d{9}|^[1-9]\d{9}$") || !Regex.IsMatch(FromAccount, @"^[0][1-9]\d{9}|^[1-9]\d{9}$")) return BadRequest();
            return Ok(_transactionService.MakeFundsTransfer(FromAccount, ToAccount, Amount, TransactionPin));
        }
        
    }
}