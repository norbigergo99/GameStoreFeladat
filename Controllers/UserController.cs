using GameStoreBeGNorbi.Context;
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
        private readonly GameStoreContext _context;

        public UserController(GameStoreContext gameStoreContext)
        {
            _context = gameStoreContext;
        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<IEnumerable<User>> GetAll()
        {
            var all = await _context.Users.Include(a => a.VideoGames).ToListAsync();
            return all;
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetById(int id)
        {
            var user = await _context.Users.Include(a => a.VideoGames).Where(a => a.Id.Equals(id)).FirstOrDefaultAsync();
            if (user == null) { return NotFound(); }
            return Ok(user);
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserDTO dto)
        {
            var salt = PasswordHasher.GenerateSalt();
            var passwordHasher = new PasswordHasher();
            var hash = passwordHasher.HashPassword(dto.Password, salt);

            try
            {
                var user = new User(
                    dto.Email,
                    hash, 
                    salt 
                );
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { ErrorMessage = ex.Message });
            }
        }
        [HttpPost("test")]
        public async Task<IActionResult> Createtest([FromBody]User user)
        {
            if (user == null) { return BadRequest(); }
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return Ok(user);

        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateUserDTO userChanges)
        {
            var user = await _context.Users.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (user == null) { return NotFound(); }
            //var emailValidator = new EmailAddressAttribute();
            //if (emailValidator.IsValid(userChanges.Email) == false) { return BadRequest(); }
            user.Email = userChanges.Email;
            await _context.SaveChangesAsync();
            return Ok();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _context.Users.Where(a => a.Id == id).FirstOrDefaultAsync();
            if(user == null) { return NotFound(); }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
