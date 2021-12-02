using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
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

        [HttpGet]
        [Route("get_by_account_number")]
        public IActionResult GetByAccountNumber(string AccountNumber)
        {

            
            if(!Regex.IsMatch(AccountNumber, @"[0][1-9]\d{9}$|^[1-9]\d{9}$")) return BadRequest(Constants.InvalidAccountNumber);

            var account = _accountService.GetByAccountNumber(AccountNumber);
            var cleanedAccount = _mapper.Map<GetAccountDto>(account);
            return Ok(cleanedAccount);
        }

        [HttpGet]
        [Route("get_by_account_id")]
        public IActionResult GetByAccountId(Guid Id)
        {
            var account = _accountService.GetById(Id);
            var cleanedAccount = _mapper.Map<GetAccountDto>(account);
            return Ok(cleanedAccount);
        }

        
        [HttpPost]
        [Route("register_new_account")]
        public IActionResult RegisterNewAccount([FromBody] RegisterNewAccountDto newAccount)
        {
            if(!ModelState.IsValid) return BadRequest(newAccount);

            var account = _mapper.Map<Account>(newAccount);
            return Ok(_accountService.Create(account, newAccount.Pin, newAccount.ConfirmPin));
        }

        [HttpPost]
        [Route("authenticate")]
        public IActionResult Autheticate([FromBody] AuthenticateDto model)
        {
            if(!ModelState.IsValid) return BadRequest();

            return Ok(_accountService.Authenticate(model.AccountNumber, model.Pin));
            //retorn account, vamos ver se quando nos rodamos antes de saber se faz map ou nao
        }

        [HttpPut]
        [Route("update_account")]
        public IActionResult UpdateAccount([FromBody] UpdateAccountDto model)
        {
            if(!ModelState.IsValid) return BadRequest(model);

            var account = _mapper.Map<Account>(model);
            
            _accountService.Update(account, model.Pin);
            return Ok();
            
        }


    }
}