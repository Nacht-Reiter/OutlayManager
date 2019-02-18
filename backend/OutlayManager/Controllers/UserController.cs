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
    public class UserController : ControllerBase
    {
        private readonly IUserService service;

        public UserController(IUserService service)
        {
            this.service = service;
        }

        // GET: User
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var user = await service.GetAllAsync();
            return user == null ? NotFound() as IActionResult : Ok(user);
        }

        // GET: User/5
        [HttpGet("{id}", Name = "GetUser")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await service.GetAsync(id);
            return user == null ? NotFound() as IActionResult : Ok(user);
        }

        // POST: User
        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] UserDTO user)
        {
            if (!ModelState.IsValid)
                return BadRequest() as IActionResult;
            var info = await service.AddAsync(user);
            return info ? Ok() : StatusCode(400);
        }

        // PUT: User/5
        [HttpPut("{id}")]
        public async Task<IActionResult> ChangeUser(int id, [FromBody] UserDTO user)
        {
            if (!ModelState.IsValid)
                return BadRequest() as IActionResult;

            var result = await service.UpdateAsync(id, user);
            return result == null ? Ok() : StatusCode(400);
        }

        // DELETE: User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var info = await service.DeleteAsync(id);
            return info ? Ok() : StatusCode(400);
        }
    }
}
