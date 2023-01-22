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
    public class StarShipsController : ControllerBase
    {
        private readonly StarWarsEncyclopediaContext _context;

        public StarShipsController(StarWarsEncyclopediaContext context)
        {
            _context = context;
        }

        // GET: api/StarShips
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StarShip>>> GetStarShips()
        {
            return await _context.StarShips.ToListAsync();
        }

        // GET: api/StarShips/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StarShip>> GetStarShip(int id)
        {
            var starShip = await _context.StarShips.FindAsync(id);

            if (starShip == null)
            {
                return NotFound();
            }

            return starShip;
        }

        // PUT: api/StarShips/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStarShip(int id, StarShip starShip)
        {
            if (id != starShip.StarshipId)
            {
                return BadRequest();
            }

            _context.Entry(starShip).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StarShipExists(id))
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

        // POST: api/StarShips
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StarShip>> PostStarShip(StarShip starShip)
        {
            _context.StarShips.Add(starShip);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStarShip", new { id = starShip.StarshipId }, starShip);
        }

        // DELETE: api/StarShips/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStarShip(int id)
        {
            var starShip = await _context.StarShips.FindAsync(id);
            if (starShip == null)
            {
                return NotFound();
            }

            _context.StarShips.Remove(starShip);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StarShipExists(int id)
        {
            return _context.StarShips.Any(e => e.StarshipId == id);
        }
    }
}
