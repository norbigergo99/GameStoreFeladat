using GameStoreBeGNorbi.Context;
using GameStoreBeGNorbi.Contracts;
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
        private readonly IRepository<VideoGame> _repository;

        public VideoGameController(IRepository<VideoGame> repo)
        {
            _repository = repo;
        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<IEnumerable<VideoGame>> GetAll()
        {
            var all = await _repository
                .GetAll();
            return all;
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VideoGame>> GetById(int id)
        {
            var game = await _repository
                .GetById(id);
            if (game == null) { return NotFound("Game not found"); }
            return Ok(game);
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] VideoGame game)
        {
            await _repository
                .Add(game);
            return Ok(game);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] VideoGame gameChanges)
        {
            var game = await _repository.GetById(id);
            if (game == null) { return NotFound("Game not found"); }
            game.Title = gameChanges.Title;
            game.Description = gameChanges.Description;
            game.Price = gameChanges.Price;
            game.Type = gameChanges.Type;
            game.Rating = gameChanges.Rating;  
            await _repository.Update(game);
            return Ok(game);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if(await _repository.GetById(id) == null) { return NotFound("Game not found"); }
            await _repository.Delete(id);
            return Ok();
        }
    }
}
