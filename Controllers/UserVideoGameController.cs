using GameStoreBeGNorbi.Context;
using GameStoreBeGNorbi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GameStoreBeGNorbi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserVideoGameController : ControllerBase
    {
        private readonly GameStoreContext _context;

        public UserVideoGameController(GameStoreContext gameStoreContext)
        {
            _context = gameStoreContext;
        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<IEnumerable<UserVideoGame>> GetAll()
        {
            var all = await _context.UserVideoGame
                .ToListAsync();
            return all;
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserVideoGame data)
        {
            var user = await _context.Users
                .FindAsync(data.UserId);
            var game = await _context.VideoGames
                .FindAsync(data.VideoGameId);
            var userVideoGame = await _context.UserVideoGame
                .Where(
                a => a.UserId.Equals(data.UserId) && 
                a.VideoGameId.Equals(data.VideoGameId))
                .FirstOrDefaultAsync();

            if (user == null || game == null) { return NotFound(); }
            if (userVideoGame != null) { return BadRequest(userVideoGame); }
                        
            await _context.UserVideoGame
                .AddAsync(data);
            await _context
                .SaveChangesAsync();
            return Ok(data);
        }
    }
}
