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
    public class DificultadsController : ControllerBase
    {
        private readonly ProyectoFdiV2Context _context;

        public DificultadsController(ProyectoFdiV2Context context)
        {
            _context = context;
        }

        // GET: api/Dificultads
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dificultad>>> GetDificultads()
        {
          if (_context.Dificultads == null)
          {
              return NotFound();
          }
            return await _context.Dificultads.ToListAsync();
        }

        // GET: api/Dificultads/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dificultad>> GetDificultad(int id)
        {
          if (_context.Dificultads == null)
          {
              return NotFound();
          }
            var dificultad = await _context.Dificultads.FindAsync(id);

            if (dificultad == null)
            {
                return NotFound();
            }

            return dificultad;
        }

        // PUT: api/Dificultads/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDificultad(int id, Dificultad dificultad)
        {
            if (id != dificultad.IdDificultad)
            {
                return BadRequest();
            }

            _context.Entry(dificultad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DificultadExists(id))
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

        // POST: api/Dificultads
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Dificultad>> PostDificultad(Dificultad dificultad)
        {
          if (_context.Dificultads == null)
          {
              return Problem("Entity set 'ProyectoFdiV2Context.Dificultads'  is null.");
          }
            _context.Dificultads.Add(dificultad);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDificultad", new { id = dificultad.IdDificultad }, dificultad);
        }

        // DELETE: api/Dificultads/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDificultad(int id)
        {
            if (_context.Dificultads == null)
            {
                return NotFound();
            }
            var dificultad = await _context.Dificultads.FindAsync(id);
            if (dificultad == null)
            {
                return NotFound();
            }

            _context.Dificultads.Remove(dificultad);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DificultadExists(int id)
        {
            return (_context.Dificultads?.Any(e => e.IdDificultad == id)).GetValueOrDefault();
        }
    }
}
