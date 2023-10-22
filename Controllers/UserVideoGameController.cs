using GameStoreBeGNorbi.Context;
using GameStoreBeGNorbi.Contracts;
using GameStoreBeGNorbi.Models;
using GameStoreBeGNorbi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GameStoreBeGNorbi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserVideoGameController : ControllerBase
    {
        private readonly IRepository<UserVideoGame> _repository;

        public UserVideoGameController(IRepository<UserVideoGame> repo)
        {
            _repository = repo;
        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<IEnumerable<UserVideoGame>> GetAll()
        {
            var all = await _repository.GetAll();
            return all;
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserVideoGame data)
        {
            /*var user = await _repository.Users
                .FindAsync(data.UserId);
            var game = await _repository.VideoGames
                .FindAsync(data.VideoGameId);
            var userVideoGame = await _repository.UserVideoGame
                .Where(
                a => a.UserId.Equals(data.UserId) && 
                a.VideoGameId.Equals(data.VideoGameId))
                .FirstOrDefaultAsync();

            if (user == null || game == null) { return NotFound(); }
            if (userVideoGame != null) { return BadRequest(userVideoGame); }
                        
            await _repository.UserVideoGame
                .AddAsync(data);
            await _repository
                .SaveChangesAsync();
            return Ok(data);*/

            await _repository.Add(data);
            if (data == null) { return NotFound(); }
            return Ok(data);
        }
    }
}
