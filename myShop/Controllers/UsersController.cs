using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Services;
using Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace myShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserServices userServices ;
        public UsersController(IUserServices _userServices)
        {
            userServices = _userServices;
        }
        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Nechami", "Platchinsky" };
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UsersController>
        [HttpPost]
        public ActionResult<User> Post([FromBody] User newUser)
        {
            userServices.addUser(newUser);
            return CreatedAtAction(nameof(Get), new { id = newUser.UserId }, newUser);


        }

        [HttpPost]
        [Route("login")]
        public ActionResult<User> PostLogin([FromQuery] string Email,string Password)
        {
            User user = userServices.getUserToLogin(Email, Password);
            if(user!=null)
                return Ok(user);
            return NoContent();
        }
        [HttpPost]
        [Route("password")]
        public ActionResult<int> PostPassword([FromBody] string Password)
        {
            int res = userServices.checkPassword(Password);
            return Ok(res);
        }
        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User updateUser)
        {
            userServices.updateUser(id,updateUser);


        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
