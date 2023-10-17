using GameStoreBeGNorbi.Context;
using GameStoreBeGNorbi.Models;
using GameStoreBeGNorbi.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GameStoreBeGNorbi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGameController : ControllerBase
    {
        private readonly GameStoreContext _context;

        public VideoGameController(GameStoreContext gameStoreContext)
        {
            _context = gameStoreContext;
        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<IEnumerable<VideoGame>> GetAll()
        {
            var all = await _context.VideoGames.ToListAsync();
            return all;
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VideoGame>> GetById(int id)
        {
            var game = await _context.VideoGames.FindAsync(id);
            if (game == null) { return NotFound(); }
            return Ok(game);
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] VideoGame game)
        {
            await _context.VideoGames.AddAsync(game);
            await _context.SaveChangesAsync();
            return Ok(game);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] VideoGame gameChanges)
        {
            var game = await _context.VideoGames.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (game == null) { return NotFound(); }
            game.Title = gameChanges.Title;
            game.Description = gameChanges.Description;
            game.Price = gameChanges.Price;
            game.Type = gameChanges.Type;
            game.Rating = gameChanges.Rating;  
            await _context.SaveChangesAsync();
            return Ok();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var game = await _context.VideoGames.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (game == null) { return NotFound(); }
            _context.VideoGames.Remove(game);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
