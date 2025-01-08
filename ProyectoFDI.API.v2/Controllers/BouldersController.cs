using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoFDI.API.v2.ModelsV4;

namespace ProyectoFDI.API.v2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BouldersController : ControllerBase
    {
        private readonly ProyectoFdiV2Context _context;

        public BouldersController(ProyectoFdiV2Context context)
        {
            _context = context;
        }

        // GET: api/Boulders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Boulder>>> GetBoulders()
        {
          if (_context.Boulders == null)
          {
              return NotFound();
          }
            return await _context.Boulders.ToListAsync();
        }

        // GET: api/Boulders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Boulder>> GetBoulder(int id)
        {
          if (_context.Boulders == null)
          {
              return NotFound();
          }
            var boulder = await _context.Boulders.FindAsync(id);

            if (boulder == null)
            {
                return NotFound();
            }

            return boulder;
        }

        // PUT: api/Boulders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBoulder(int id, Boulder boulder)
        {
            if (id != boulder.IdBoulder)
            {
                return BadRequest();
            }

            _context.Entry(boulder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BoulderExists(id))
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

        // POST: api/Boulders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Boulder>> PostBoulder(Boulder boulder)
        {
          if (_context.Boulders == null)
          {
              return Problem("Entity set 'ProyectoFdiV2Context.Boulders'  is null.");
          }
            _context.Boulders.Add(boulder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBoulder", new { id = boulder.IdBoulder }, boulder);
        }

        // DELETE: api/Boulders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBoulder(int id)
        {
            if (_context.Boulders == null)
            {
                return NotFound();
            }
            var boulder = await _context.Boulders.FindAsync(id);
            if (boulder == null)
            {
                return NotFound();
            }

            _context.Boulders.Remove(boulder);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BoulderExists(int id)
        {
            return (_context.Boulders?.Any(e => e.IdBoulder == id)).GetValueOrDefault();
        }
    }
}
