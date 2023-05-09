using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SteamCopy.Data;
using SteamCopy.Models;
using System.Threading.Tasks.Dataflow;

namespace SteamCopy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SteamCopyController : ControllerBase
    {
        private readonly SteamCopyContext _context;

        public SteamCopyController(SteamCopyContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<SteamGame> allGames = new List<SteamGame>();

            long sizeOfSteamGames = _context.SteamGames.LongCount();

            for (long i = 1; i < sizeOfSteamGames + 1; i++)
            {
                var steamGame = _context.SteamGames.Where(x => x.Id == i).FirstOrDefault();
                if (steamGame == null)
                {
                    continue;
                }

                var steamGameDetail = _context.SteamGameDetails.Where(x => x.SteamGameId == steamGame.Id).FirstOrDefault();
                steamGame.SteamGameDetail = steamGameDetail;

                allGames.Add(steamGame);
            }

            return Ok(allGames);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SteamGame>> GetById(int id)
        {
            var steamGame = _context.SteamGames.Where(x => x.Id == id).FirstOrDefault();
            if (steamGame == null)
            {
                return BadRequest("Game Not Found!");
            }

            var steamGameDetail = _context.SteamGameDetails.Where(x => x.Id == steamGame.Id).FirstOrDefault();

            steamGame.SteamGameDetail = steamGameDetail;

            return Ok(steamGame);
        }

        [HttpPost]
        public async Task<ActionResult<SteamGame>> AddNewSteamGame([FromBody] SteamGame steamGame)
        {
            SteamGameDetail steamGameDetail = steamGame.SteamGameDetail;
            _context.SteamGames.Add(steamGame);
            _context.SteamGameDetails.Add(steamGameDetail);

            _context.SaveChanges();

            return Ok(steamGame);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<SteamGame>> DeleteGame(int id)
        {
            var steamGame = _context.SteamGames.Where(x => x.Id == id).FirstOrDefault();
            if (steamGame == null)
            {
                return BadRequest("Game NOt FOUND!");
            }
            _context.SteamGames.Remove(steamGame);

            var steamGameDetail = _context.SteamGameDetails.Where(x => x.SteamGameId == steamGame.Id).FirstOrDefault();
            _context.SteamGameDetails.Remove(steamGameDetail);

            _context.SaveChanges();

            return Ok(steamGame);
        }

        [HttpPut]
        public async Task<ActionResult<SteamGame>> UpdateGame([FromBody] SteamGame steamGame)
        {
            _context.SteamGames.Update(steamGame);
            _context.SaveChanges();
            return Ok(steamGame);
        }

    }
}
