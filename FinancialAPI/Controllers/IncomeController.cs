using FinancialAPI.DataContext;
using FinancialAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncomeController : ControllerBase
    {
        private readonly ApplicationDbContext _incomeDbContext;

        public IncomeController(ApplicationDbContext incomeDbContext)
        {
            _incomeDbContext = incomeDbContext;
        }

        // GET: api/<IncomeController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Income>>> Get()
        {
            return Ok(await _incomeDbContext.Income.ToListAsync());
        }

        // GET api/<IncomeController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Income>> Get(int id)
        {
            return Ok(await _incomeDbContext.Income.FindAsync(id));
        }

        // POST api/<IncomeController>
        [HttpPost]
        public async Task<ActionResult<Income>> Create([FromBody] Income income)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            income.Created_at = DateTime.Now;
            await _incomeDbContext.Income.AddAsync(income);
            await _incomeDbContext.SaveChangesAsync();
            return Ok(income);
        }

        // PUT api/<IncomeController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Income>> Update(int id, [FromBody] Income incomeFromJson)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var income = await _incomeDbContext.Income.FindAsync(id);
            if (income == null)
            {
                return NotFound();
            }
            income.Date = incomeFromJson.Date;
            income.Value = incomeFromJson.Value;
            income.Description = incomeFromJson.Description;
            income.Updated_at = DateTime.Now;
            await _incomeDbContext.SaveChangesAsync();
            return Ok(income);
        }

        // DELETE api/<IncomeController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Income>> Delete(int id)
        {
            var income = await _incomeDbContext.Income.FindAsync(id);
            if (income == null)
            {
                return NotFound();
            }
            _incomeDbContext.Remove(income);
            await _incomeDbContext.SaveChangesAsync();
            return Ok(income);
        }
    }
}
