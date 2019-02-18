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
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService service;

        public TransactionController(ITransactionService service)
        {
            this.service = service;
        }

        // GET: Transaction
        [HttpGet]
        public async Task<IActionResult> GetAllTransactions()
        {
            var transaction = await service.GetAllAsync();
            return transaction == null ? NotFound() as IActionResult : Ok(transaction);
        }

        // GET: Transaction/5
        [HttpGet("{id}", Name = "GetTransaction")]
        public async Task<IActionResult> GetTransaction(int id)
        {
            var transaction = await service.GetAsync(id);
            return transaction == null ? NotFound() as IActionResult : Ok(transaction);
        }

        // POST: Transaction
        [HttpPost]
        public async Task<IActionResult> AddTransaction([FromBody] TransactionDTO transaction)
        {
            if (!ModelState.IsValid)
                return BadRequest() as IActionResult;
            var info = await service.AddAsync(transaction);
            return info ? Ok() : StatusCode(400);
        }

        // PUT: Transaction/5
        [HttpPut("{id}")]
        public async Task<IActionResult> ChangeTransaction(int id, [FromBody] TransactionDTO transaction)
        {
            if (!ModelState.IsValid)
                return BadRequest() as IActionResult;

            var result = await service.UpdateAsync(id, transaction);
            return result == null ? Ok() : StatusCode(400);
        }

        // DELETE: Transaction/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransaction(int id)
        {
            var info = await service.DeleteAsync(id);
            return info ? Ok() : StatusCode(400);
        }
    }
}
