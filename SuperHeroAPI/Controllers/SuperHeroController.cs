using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Data.EfCore;
using SuperHeroAPI.Services;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {

        IAdminService _service;

        public SuperHeroController(IAdminService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.GetAllSuperHeroes()); // StatusCode 200 (everything went fine)
        }

        [HttpGet("{id}")] // Parameter for the route
        public IActionResult GetById(int id)
        {
            var hero = _service.GetSuperHeroById(id);
            if(hero == null)
            {
                return BadRequest("Hero not found.");
            } else
            {
                return Ok(hero);
            }
        }

        [HttpPost]
        public IActionResult AddHero(SuperHero hero)
        {
            _service.AddSuperHero(hero);

            return Ok(hero); // StatusCode 200 (everything went fine)
        }

        [HttpPut]
        public IActionResult UpdateHero(SuperHero superHero) // Refactor
        {
            if(_service.GetSuperHeroById(superHero.Id) == null)
            {
                return NotFound();
            } else
            {
                _service.UpdateSuperHero(superHero);
                return Ok(superHero);
            }
        }

        [HttpDelete("{id}")] // Parameter for the route
        public IActionResult Delete(int id)
        {
            var superHero = _service.GetSuperHeroById(id);
            if(superHero == null)
            {
                return NotFound();
            } else
            {
                _service.DeleteSuperHero(superHero);
                return NoContent();
            }
        }
    }
}
