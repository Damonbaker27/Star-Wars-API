using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using starWarsAPI.Data;
using starWarsAPI.Models.Entities;

namespace starWarsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeworldsController : ControllerBase
    {
        private readonly StarWarsEncyclopediaContext _context;

        public HomeworldsController(StarWarsEncyclopediaContext context)
        {
            _context = context;
        }

        // GET: api/Homeworlds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Homeworld>>> GetHomeworlds()
        {
            return await _context.Homeworlds.ToListAsync();
        }

        // GET: api/Homeworlds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Homeworld>> GetHomeworld(int id)
        {
            var homeworld = await _context.Homeworlds.FindAsync(id);

            if (homeworld == null)
            {
                return NotFound();
            }

            return homeworld;
        }

        // PUT: api/Homeworlds/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHomeworld(int id, Homeworld homeworld)
        {
            if (id != homeworld.HomeWorldId)
            {
                return BadRequest();
            }

            _context.Entry(homeworld).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HomeworldExists(id))
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

        // POST: api/Homeworlds
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Homeworld>> PostHomeworld(Homeworld homeworld)
        {
            _context.Homeworlds.Add(homeworld);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHomeworld", new { id = homeworld.HomeWorldId }, homeworld);
        }

        // DELETE: api/Homeworlds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHomeworld(int id)
        {
            var homeworld = await _context.Homeworlds.FindAsync(id);
            if (homeworld == null)
            {
                return NotFound();
            }

            _context.Homeworlds.Remove(homeworld);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HomeworldExists(int id)
        {
            return _context.Homeworlds.Any(e => e.HomeWorldId == id);
        }
    }
}
