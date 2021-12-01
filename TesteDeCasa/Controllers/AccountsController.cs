using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TesteDeCasa.Dtos;
using TesteDeCasa.Models;
using TesteDeCasa.Services.Interfaces;

namespace TesteDeCasa.Controllers
{
    [ApiController]
    [Route("api/v3/[controller]")]
    public class AccountsController : ControllerBase
    {
        private IAccountService _accountService;
        IMapper _mapper;

        public AccountsController(IAccountService accountService, IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;            
        }

        [HttpGet]
        [Route("get_all_accounts")]
        public IActionResult GetAllAccounts()
        {
            var accounts = _accountService.GetAllAccounts();
            var cleanedAccounts = _mapper.Map<IList<GetAccountDto>>(accounts);
            
            return Ok(cleanedAccounts);
        }

        [HttpPost]
        [Route("register_new_account")]
        public IActionResult RegisterNewAccount([FromBody] RegisterNewAccountDto newAccount)
        {
            if(!ModelState.IsValid) return BadRequest(newAccount);

            var account = _mapper.Map<Account>(newAccount);
            return Ok(_accountService.Create(account, newAccount.Pin, newAccount.ComfirmPin));
        }
    
        
    }
}