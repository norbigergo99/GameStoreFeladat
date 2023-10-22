using GameStoreBeGNorbi.Context;
using GameStoreBeGNorbi.Contracts;
using GameStoreBeGNorbi.Models;
using GameStoreBeGNorbi.Resources;
using GameStoreBeGNorbi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GameStoreBeGNorbi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepository<User> _repository;

        public UserController(IRepository<User> repo)
        {
            _repository = repo;
        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<IEnumerable<User>> GetAll()
        {
            var all = await _repository
                .GetAll();
            return all;
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetById(int id)
        {
            var user = await _repository
                .GetById(id);
            if (user == null) { return NotFound("User not found"); }
            return Ok(user);
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserDTO dto)
        {
            var salt = PasswordHasher
                .GenerateSalt();
            var passwordHasher = new PasswordHasher();
            var hash = passwordHasher
                .HashPassword(dto.Password, salt);

            try
            {
                var user = new User(
                    dto.Email,
                    hash, 
                    salt 
                );
                await _repository
                    .Add(user);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateUserDTO userChanges)
        {
            var user = await _repository
                .GetById(id);
            if (user == null) { return NotFound("User not found"); }
            user.Email = userChanges.Email;
            await _repository
                .Update(user);
            return Ok();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _repository.GetById(id) == null) { return NotFound("User not found"); }
            await _repository
                .Delete(id);
            return Ok();
        }
    }
}
