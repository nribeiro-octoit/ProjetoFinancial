using FinancialAPI.DataContext;
using FinancialAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinancialAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbContext _categoryDbContext;

        public CategoryController(ApplicationDbContext categoryDbContext)
        {
            _categoryDbContext = categoryDbContext;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> Get()
        {
            return Ok(await _categoryDbContext.Category.ToListAsync());
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> Get(int id)
        {
            return Ok(await _categoryDbContext.Category.FindAsync(id));
        }

        // POST api/<CategoryController>
        [HttpPost]
        public async Task<ActionResult<Category>> Create([FromBody] Category category)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            category.Created_at = DateTime.Now;
            await _categoryDbContext.Category.AddAsync(category);
            await _categoryDbContext.SaveChangesAsync();
            return Ok(category);
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Category>> Update(int id, [FromBody] Category categoryFromJson)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var category = await _categoryDbContext.Category.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            category.Description = categoryFromJson.Description;
            category.Updated_at = DateTime.Now;
            await _categoryDbContext.SaveChangesAsync();
            return Ok(category);
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Expense>> Delete(int id)
        {
            var category = await _categoryDbContext.Category.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            _categoryDbContext.Remove(category);
            await _categoryDbContext.SaveChangesAsync();
            return Ok(category);
        }
    }
}
