using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockInvestment.Models;
using StockInvestment.Services;

namespace StockInvestment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IRepositoryUsers _repository;

        public UsersController(IRepositoryUsers repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _repository.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _repository.GetUserById(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] User user)
        {
            if (user == null)
                return BadRequest();

            _repository.CreateUser(user);
            return CreatedAtAction(nameof(GetUserById), new { id = user.UserId }, user);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] User user)
        {
            if (id != user.UserId)
                return BadRequest("User ID mismatch");

            var existingUser = _repository.GetUserById(id);

            if (existingUser == null)
                return NotFound("User not found");


            existingUser.Username = user.Username;
            existingUser.PasswordHash = user.PasswordHash;


            _repository.UpdateUser(existingUser);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            //if (id != user.UserId)
            //    return BadRequest("User ID mismatch");

            var existingUser = _repository.GetUserById(id);

            if (existingUser == null)
                return NotFound("User not found");

            _repository.DeleteUser(id);

            return Ok("User deleted successfully" );
        }


    }
}
