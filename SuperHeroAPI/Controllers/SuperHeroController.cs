﻿using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            return Ok(heroes); // StatusCode 200 (everything went fine)
        }

        [HttpGet("{id}")] // Parameter for the route
        public async Task<ActionResult<List<SuperHero>>> Get(int id)
        {
            var hero = heroes.Find(h => h.Id == id);
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
            heroes.Add(hero);
            return Ok(heroes); // StatusCode 200 (everything went fine)
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero request) // Refactor
        {
            var hero = heroes.Find(h => h.Id == request.Id);
            if(hero == null)
            {
                return BadRequest("Hero not found.");
            } else
            {
                hero.Name = request.Name;
                hero.FirstName = request.FirstName;
                hero.LastName = request.LastName;
                hero.Place = request.Place;

                return Ok(hero);
            }
        }

        [HttpDelete("{id}")] // Parameter for the route
        public async Task<ActionResult<List<SuperHero>>> Delete(int id)
        {
            var hero = heroes.Find(h => h.Id == id);
            if (hero == null)
            {
                return BadRequest("Hero not found.");
            }
            else
            {
                heroes.Remove(hero);
                return Ok(hero);
            }
        }
    }
}
