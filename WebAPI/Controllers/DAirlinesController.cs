using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DAirlinesController : ControllerBase
    {
        private readonly AirlineDBContext _context;

        public DAirlinesController(AirlineDBContext context)
        {
            _context = context;
        }

        // GET: api/DAirlines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DAirlines>>> GetDAirlines()
        {
            return await _context.DAirlines.ToListAsync();
        }

        // GET: api/DAirlines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DAirlines>> GetDAirlines(int id)
        {
            var dAirlines = await _context.DAirlines.FindAsync(id);

            if (dAirlines == null)
            {
                return NotFound();
            }

            return dAirlines;
        }

        // PUT: api/DAirlines/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDAirlines(int id, DAirlines dAirlines)
        {
            dAirlines.id=id;

            _context.Entry(dAirlines).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DAirlinesExists(id))
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

        // POST: api/DAirlines
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<DAirlines>> PostDAirlines(DAirlines dAirlines)
        {
            _context.DAirlines.Add(dAirlines);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDAirlines", new { id = dAirlines.id }, dAirlines);
        }

        // DELETE: api/DAirlines/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DAirlines>> DeleteDAirlines(int id)
        {
            var dAirlines = await _context.DAirlines.FindAsync(id);
            if (dAirlines == null)
            {
                return NotFound();
            }

            _context.DAirlines.Remove(dAirlines);
            await _context.SaveChangesAsync();

            return dAirlines;
        }

        private bool DAirlinesExists(int id)
        {
            return _context.DAirlines.Any(e => e.id == id);
        }
    }
}
