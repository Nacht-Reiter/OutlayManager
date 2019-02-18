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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService service;

        public CategoryController(ICategoryService service)
        {
            this.service = service;
        }

        // GET: Category
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await service.GetAllAsync();
            return categories == null ? NotFound() as IActionResult : Ok(categories);
        }

        // GET: Category/5
        [HttpGet("{id}", Name = "GetCategory")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var category = await service.GetAsync(id);
            return category == null ? NotFound() as IActionResult : Ok(category);
        }

        // POST: Category
        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] CategoryDTO category)
        {
            if (!ModelState.IsValid)
                return BadRequest() as IActionResult;
            var info = await service.AddAsync(category);
            return info ? Ok() : StatusCode(400);
        }

        // PUT: Category/5
        [HttpPut("{id}")]
        public async Task<IActionResult> ChangeCategory(int id, [FromBody] CategoryDTO category)
        {
            if (!ModelState.IsValid)
                return BadRequest() as IActionResult;

            var result = await service.UpdateAsync(id, category);
            return result == null ? Ok() : StatusCode(400);
        }

        // DELETE: Category/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var info = await service.DeleteAsync(id);
            return info ? Ok() : StatusCode(400);
        }
    }
}
