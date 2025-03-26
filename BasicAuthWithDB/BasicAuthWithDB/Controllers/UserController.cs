using BasicAuthWithDB.Data;
using BasicAuthWithDB.Models.DTO;
using BasicAuthWithDB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasicAuthWithDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UsersDBContext dbContext;
        public UserController(UsersDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register(UserDTO user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var objUser = dbContext.Users.FirstOrDefault(u => u.Email == user.Email);
            if (objUser == null)
            {
                dbContext.Users.Add(new User
                { FirstName = user.FirstName, LastName = user.LastName, Email = user.Email, Password = user.Password });
                dbContext.SaveChanges();
                return Ok("User registered successfully.");
            }
            else
            {
                return BadRequest("User already registered with the same Email.");
            }
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginDTO user)
        {
            var validUser = dbContext.Users.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password && u.IsActive == true);
            if (validUser == null)
                return NotFound();
            return Ok(validUser);
        }

        [HttpGet]
        [Route("GetUserProfile")]
        public IActionResult GetUserProfile(int userId)
        {
            var user = dbContext.Users.FirstOrDefault(u => u.UserId == userId);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        [HttpGet]
        [Route("GetUsers")]
        public IActionResult GetUsers()
        {
            var users = dbContext.Users.ToList();
            if (users == null)
                return NotFound();
            return Ok(users);
        }
    }
}