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
    public class ReponseAPIController : ControllerBase
    {
        private readonly QuestionContext _context;

        public ReponseAPIController(QuestionContext context)
        {
            _context = context;
        }

        // GET: api/ReponseAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reponse>>> GetReponse()
        {
            return await _context.Reponse.ToListAsync();
        }

        // GET: api/ReponseAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reponse>> GetReponse(int id)
        {
            var reponse = await _context.Reponse.FindAsync(id);

            if (reponse == null)
            {
                return NotFound();
            }

            return reponse;
        }

        // PUT: api/ReponseAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReponse(int id, Reponse reponse)
        {
            if (id != reponse.ResponseId)
            {
                return BadRequest();
            }

            _context.Entry(reponse).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReponseExists(id))
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

        // POST: api/ReponseAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Reponse>> PostReponse(Reponse reponse)
        {
            _context.Reponse.Add(reponse);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReponse", new { id = reponse.ResponseId }, reponse);
        }

        // DELETE: api/ReponseAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReponse(int id)
        {
            var reponse = await _context.Reponse.FindAsync(id);
            if (reponse == null)
            {
                return NotFound();
            }

            _context.Reponse.Remove(reponse);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReponseExists(int id)
        {
            return _context.Reponse.Any(e => e.ResponseId == id);
        }
    }
}
