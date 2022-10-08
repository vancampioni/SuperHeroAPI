using Microsoft.AspNetCore.Mvc;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private static List<SuperHero> heroes = new List<SuperHero> // Have access from everywhere
            {
                new SuperHero {
                    Id = 1,
                    Name = "Spider Man",
                    FirstName = "Peter",
                    LastName = "Parker",
                    Place = "New York City"
                },

                new SuperHero {
                    Id = 2,
                    Name = "Wonder Woman",
                    FirstName = "Diana",
                    LastName = "Prince",
                    Place = "Themyscira"
                }
            };
        private readonly DataContext _context;

        public SuperHeroController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            return Ok(await _context.SuperHeroes.ToListAsync()); // StatusCode 200 (everything went fine)
        }

        [HttpGet("{id}")] // Parameter for the route
        public async Task<ActionResult<List<SuperHero>>> GetById(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if(hero == null)
            {
                return BadRequest("Hero not found.");
            } else
            {
                return Ok(hero);
            }
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            _context.SuperHeroes.Add(hero);
            await _context.SaveChangesAsync(); 

            return Ok(await _context.SuperHeroes.ToListAsync()); // StatusCode 200 (everything went fine)
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero request) // Refactor
        {
            var dbHero = await _context.SuperHeroes.FindAsync(request.Id);
            if (dbHero == null)
            {
                return BadRequest("Hero not found.");
            } else
            {
                dbHero.Name = request.Name;
                dbHero.FirstName = request.FirstName;
                dbHero.LastName = request.LastName;
                dbHero.Place = request.Place;

                await _context.SaveChangesAsync();

                return Ok(await _context.SuperHeroes.ToListAsync());
            }
        }

        [HttpDelete("{id}")] // Parameter for the route
        public async Task<ActionResult<List<SuperHero>>> Delete(int id)
        {
            var dbHero = await _context.SuperHeroes.FindAsync(id);
            if (dbHero == null)
            {
                return BadRequest("Hero not found.");
            }
            else
            {
                _context.SuperHeroes.Remove(dbHero);
                await _context.SaveChangesAsync();
                return Ok(await _context.SuperHeroes.ToListAsync());
            }
        }
    }
}
