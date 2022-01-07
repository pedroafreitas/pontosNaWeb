using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TesteDeCasa.Dtos;
using TesteDeCasa.Models;
using TesteDeCasa.Services.Interfaces;
using TesteDeCasa.Utils;

namespace TesteDeCasa.Controllers
{
    [ApiController]
    [Route("api/v3/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public AccountsController(IAccountService accountService, IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;            
        }

        [HttpGet]
        [Route("get_all_accounts")]
        public async Task<IActionResult> GetAllAccountsAsync()
        {
            var accounts = await _accountService.GetAllAccountsAsync();
            var cleanedAccounts = _mapper.Map<IList<GetAccountDto>>(accounts);
            
            return Ok(cleanedAccounts);
        }

        [HttpGet]
        [Route("get_by_account_number")]
        public async Task<IActionResult> GetByAccountNumberAsync(string AccountNumber)
        {   
            if(!Regex.IsMatch(AccountNumber, @"[0][1-9]\d{9}$|^[1-9]\d{9}$")) return BadRequest(Constants.InvalidAccountNumber);

            var account = await _accountService.GetByAccountNumberAsync(AccountNumber);
            var cleanedAccount = _mapper.Map<GetAccountDto>(account);
            return Ok(cleanedAccount);
        }

        [HttpGet]
        [Route("get_by_account_id")]
        public async Task<IActionResult> GetByAccountIdAsync(Guid Id)
        {
            var account = await _accountService.GetByIdAsync(Id);
            var cleanedAccount = _mapper.Map<GetAccountDto>(account);
            return Ok(cleanedAccount);
        }

        
        [HttpPost]
        [Route("register_new_account")]
        public async Task<IActionResult> RegisterNewAccountAsync([FromBody] RegisterNewAccountDto newAccount)
        {
            if(!ModelState.IsValid) return BadRequest(newAccount);

            var account = _mapper.Map<Account>(newAccount);
            return Ok(await _accountService.CreateAsync(account, newAccount.Pin, newAccount.ConfirmPin));
        }

        [HttpPost]
        [Route("authenticate")]
        public async Task<IActionResult> AutheticateAsync([FromBody] AuthenticateDto model)
        {
            if(!ModelState.IsValid) return BadRequest();

            return Ok(await _accountService.AuthenticateAsync(model.AccountNumber, model.Pin));
        }

        [HttpPut]
        [Route("update_account")]
        public async Task<IActionResult> UpdateAccountAsync([FromBody] UpdateAccountDto model)
        {
            if(!ModelState.IsValid) return BadRequest(model);

            var account = _mapper.Map<Account>(model);
            
            await _accountService.UpdateAsync(account, model.Pin);
            return Ok();
            
        }
    }
}