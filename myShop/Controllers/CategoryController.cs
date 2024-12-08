using Microsoft.AspNetCore.Mvc;
using Entities;
using Reposetories;
using Services;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace myShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryServices categoryServices;
        public CategoryController(ICategoryServices _ICategoryServices)
        {
            categoryServices = _ICategoryServices;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<IEnumerable<Category>> Get()
        {
            return await categoryServices.getAllCategories();
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "";
        }

        // POST api/<CategoryController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
