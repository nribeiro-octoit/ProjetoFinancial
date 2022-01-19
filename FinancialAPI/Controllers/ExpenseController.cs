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
    public class ExpenseController : ControllerBase
    {
        private readonly ApplicationDbContext _expenseDbContext;

        public ExpenseController(ApplicationDbContext expenseDbContext)
        {
            _expenseDbContext = expenseDbContext;
        }

        // GET: api/<ExpenseController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Expense>>> Get()
        {
            return Ok(await _expenseDbContext.Expense.ToListAsync());
        }

        // GET api/<ExpenseController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Expense>> Get(int id)
        {
            return Ok(await _expenseDbContext.Expense.FindAsync(id));
        }

        // POST api/<ExpenseController>
        [HttpPost]
        public async Task<ActionResult<Expense>> Create([FromBody] Expense expense)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            expense.Created_at = DateTime.Now;
            await _expenseDbContext.Expense.AddAsync(expense);
            await _expenseDbContext.SaveChangesAsync();
            return Ok(expense);
        }

        // PUT api/<ExpenseController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Expense>> Update(int id, [FromBody] Expense expenseFromJson)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var expense = await _expenseDbContext.Expense.FindAsync(id);
            if (expense == null)
            {
                return NotFound();
            }
            expense.Date = expenseFromJson.Date;
            expense.Value = expenseFromJson.Value;
            expense.Description = expenseFromJson.Description;
            expense.Updated_at = DateTime.Now;
            await _expenseDbContext.SaveChangesAsync();
            return Ok(expense);
        }

        // DELETE api/<ExpenseController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Expense>> Delete(int id)
        {
            var expense = await _expenseDbContext.Expense.FindAsync(id);
            if (expense == null)
            {
                return NotFound();
            }
            _expenseDbContext.Remove(expense);
            await _expenseDbContext.SaveChangesAsync();
            return Ok(expense);
        }
    }
}
