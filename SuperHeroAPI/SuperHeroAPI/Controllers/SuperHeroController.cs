using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Data;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        /*
        private static List<SuperHero> heroes = new List<SuperHero>
        {
            new SuperHero {
                Id = 1,
                Name = "Spiderman",
                FirstName = "Peter",
                LastName = "Parker",
                Place = "New York"
            },

            new SuperHero {
                Id = 2,
                Name = "Batman",
                FirstName = "Bruce",
                LastName = "Wayne",
                Place = "Arkham City"
            }
         };
        */
        private readonly SuperHeroContext _context;

        public SuperHeroController(SuperHeroContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _context.SuperHeroes.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> Get(int id)
        {
            // var hero = heroes.Find(x => x.Id == id);

            var hero = _context.SuperHeroes.Where(x => x.Id == id).FirstOrDefault();
            if (hero == null)
                    return BadRequest("Hero Not Found");
            return Ok(hero);
        }


        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero([FromBody]SuperHero hero)
        {
            _context.SuperHeroes.Add(hero);
            _context.SaveChanges();
            return Ok(_context.SuperHeroes);
        }

        [HttpPut(Name="PutNewHeroOrEditExisting")]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero([FromBody] SuperHero _hero)
        {
            // var hero = heroes.Find(x => x.Id == _hero.Id);
            var hero = _context.SuperHeroes.Where(x => x.Id == _hero.Id).FirstOrDefault();
            if (hero == null)
                return BadRequest("Hero Not Found");

            hero.Name = _hero.Name;
            hero.FirstName = _hero.FirstName;
            hero.LastName = _hero.LastName;
            hero.Place = _hero.Place;

            _context.SaveChanges();

            return Ok(_context.SuperHeroes);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            // var hero = heroes.Find(x => x.Id == id);
            var hero = _context.SuperHeroes.Where(x => x.Id == id).FirstOrDefault();
            if (hero == null)
                return BadRequest("Hero Not Found");
            _context.SuperHeroes.Remove(hero);
            _context.SaveChanges();
            return Ok(_context.SuperHeroes);
        }
    }
}
