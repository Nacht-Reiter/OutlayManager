using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OutlayManager.BusinessLogic.Interfaces;
using OutlayManager.Common.DTOs;

namespace OutlayManager.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService service;

        public AccountController(IAccountService service)
        {
            this.service = service;
        }

        // GET: Account
        [HttpGet]
        public async Task<IActionResult> GetAllAccounts()
        {
            var account = await service.GetAllAsync();
            return account == null ? NotFound() as IActionResult : Ok(account);
        }

        // GET: Account/5
        [HttpGet("{id}", Name = "GetAccount")]
        public async Task<IActionResult> GetAccount(int id)
        {
            var account = await service.GetAsync(id);
            return account == null ? NotFound() as IActionResult : Ok(account);
        }

        // POST: Account
        [HttpPost]
        public async Task<IActionResult> AddAccount([FromBody] AccountDTO account)
        {
            if (!ModelState.IsValid)
                return BadRequest() as IActionResult;
            var info = await service.AddAsync(account);
            return info ? Ok() : StatusCode(400);
        }

        // PUT: Account/5
        [HttpPut("{id}")]
        public async Task<IActionResult> ChangeAccount(int id, [FromBody] AccountDTO account)
        {
            if (!ModelState.IsValid)
                return BadRequest() as IActionResult;

            var result = await service.UpdateAsync(id, account);
            return result == null ? Ok() : StatusCode(400);
        }

        // DELETE: Account/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            var info = await service.DeleteAsync(id);
            return info ? Ok() : StatusCode(400);
        }
    }
}
