using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Question.Data;
using QuestionFC.Models;

namespace QuestionFC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OptionAPIController : ControllerBase
    {
        private readonly QuestionContext _context;

        public OptionAPIController(QuestionContext context)
        {
            _context = context;
        }

        // GET: api/OptionAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Option>>> GetOption()
        {
            return await _context.Option.ToListAsync();
        }

        // GET: api/OptionAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Option>> GetOption(int id)
        {
            var option = await _context.Option.FindAsync(id);

            if (option == null)
            {
                return NotFound();
            }

            return option;
        }

        // PUT: api/OptionAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOption(int id, Option option)
        {
            if (id != option.OptionId)
            {
                return BadRequest();
            }

            _context.Entry(option).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OptionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/OptionAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Option>> PostOption(Option option)
        {
            _context.Option.Add(option);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOption", new { id = option.OptionId }, option);
        }

        // DELETE: api/OptionAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOption(int id)
        {
            var option = await _context.Option.FindAsync(id);
            if (option == null)
            {
                return NotFound();
            }

            _context.Option.Remove(option);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OptionExists(int id)
        {
            return _context.Option.Any(e => e.OptionId == id);
        }
    }
}
