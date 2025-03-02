using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Services;
using Entities;
using DTO;
using AutoMapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace myShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserServices userServices ;
        IMapper _mapper;
        public UsersController(IUserServices _userServices, IMapper mapper)
        {
            userServices = _userServices;
            _mapper = mapper;
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<User> Get(int id)
        {
            return await userServices.getUserById(id);
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<ActionResult<User>> Post([FromBody] UserDTO newUser)
        {
            User user = _mapper.Map<UserDTO,User>(newUser);
            //int num = userServices.checkPassword(newUser.Password);
            User user1= await userServices.addUser(user);
            if (user1 != null)
            {
                return CreatedAtAction(nameof(Get), new { id = newUser.UserId }, user1);
            }
            else
            {
                return BadRequest("week password");
            }


        }
        //iii
        //iiii
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult <ReturnUserDTO>> PostLogin([FromQuery] string Email,string Password)//רק ID 
        {
            User user =await userServices.getUserToLogin(Email, Password);
            ReturnUserDTO returnUser = _mapper.Map<User, ReturnUserDTO>(user);
            if(user!=null)
                return Ok(returnUser);
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
        public async Task<ActionResult<string>> Put(int id, [FromBody] UserDTO updateUser)
        {

            User user = _mapper.Map<UserDTO, User>(updateUser);
            int num = userServices.checkPassword(user.Password);
            User user1 = await userServices.updateUser(id, user);
            if (user1!=null)
            {
                return Ok();
            }
            else
            {
                 return BadRequest("week password");
            }

            


        }

        
    }
}
