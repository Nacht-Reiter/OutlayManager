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
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyService service;

        public CurrencyController(ICurrencyService service)
        {
            this.service = service;
        }

        // GET: Currency
        [HttpGet]
        public async Task<IActionResult> GetAllCurrencies()
        {
            var currencies = await service.GetAllAsync();
            return currencies == null ? NotFound() as IActionResult : Ok(currencies);
        }

        // GET: Currency/5
        [HttpGet("{id}", Name = "GetCurrency")]
        public async Task<IActionResult> GetCurrency(int id)
        {
            var currency = await service.GetAsync(id);
            return currency == null ? NotFound() as IActionResult : Ok(currency);
        }

        // POST: Currency
        [HttpPost]
        public async Task<IActionResult> AddCurrency([FromBody] CurrencyDTO currency)
        {
            if (!ModelState.IsValid)
                return BadRequest() as IActionResult;
            var info = await service.AddAsync(currency);
            return info ? Ok() : StatusCode(400);
        }

        // PUT: Currency/5
        [HttpPut("{id}")]
        public async Task<IActionResult> ChangeCurrency(int id, [FromBody] CurrencyDTO currency)
        {
            if (!ModelState.IsValid)
                return BadRequest() as IActionResult;

            var result = await service.UpdateAsync(id, currency);
            return result == null ? Ok() : StatusCode(400);
        }

        // DELETE: Currency/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCurrency(int id)
        {
            var info = await service.DeleteAsync(id);
            return info ? Ok() : StatusCode(400);
        }
    }
}
