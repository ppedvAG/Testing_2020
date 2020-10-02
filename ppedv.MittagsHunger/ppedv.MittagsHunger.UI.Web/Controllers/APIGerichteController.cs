using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ppedv.MittagsHunger.Model;
using ppedv.MittagsHunger.UI.Web.Data;

namespace ppedv.MittagsHunger.UI.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIGerichteController : ControllerBase
    {
        private readonly ppedvMittagsHungerUIWebContext _context;

        public APIGerichteController(ppedvMittagsHungerUIWebContext context)
        {
            _context = context;
        }

        // GET: api/APIGerichte
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gericht>>> GetGericht()
        {
            return await _context.Gericht.ToListAsync();
        }

        // GET: api/APIGerichte/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Gericht>> GetGericht(int id)
        {
            var gericht = await _context.Gericht.FindAsync(id);

            if (gericht == null)
            {
                return NotFound();
            }

            return gericht;
        }

        // PUT: api/APIGerichte/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGericht(int id, Gericht gericht)
        {
            if (id != gericht.Id)
            {
                return BadRequest();
            }

            _context.Entry(gericht).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GerichtExists(id))
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

        // POST: api/APIGerichte
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Gericht>> PostGericht(Gericht gericht)
        {
            _context.Gericht.Add(gericht);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGericht", new { id = gericht.Id }, gericht);
        }

        // DELETE: api/APIGerichte/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Gericht>> DeleteGericht(int id)
        {
            var gericht = await _context.Gericht.FindAsync(id);
            if (gericht == null)
            {
                return NotFound();
            }

            _context.Gericht.Remove(gericht);
            await _context.SaveChangesAsync();

            return gericht;
        }

        private bool GerichtExists(int id)
        {
            return _context.Gericht.Any(e => e.Id == id);
        }
    }
}
