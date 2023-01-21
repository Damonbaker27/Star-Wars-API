using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using starWarsAPI.Data;

namespace starWarsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeWorldController : Controller
    {
        private readonly StarWarsEncyclopediaContext db;


        public HomeWorldController(StarWarsEncyclopediaContext db)
        {
            this.db = db;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllHomeworlds()
        {
            var homeworlds = await db.Homeworlds.ToListAsync();

            return Ok(homeworlds);
        }


        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetHomeWorld(int id)
        {

            var homeWorld =  await db.Homeworlds.FirstOrDefaultAsync(x => x.HomeWorldId == id);

           if(homeWorld != null)
           {
                return Ok(homeWorld);
           }
            
            return NotFound();

        }
      







    }
}
