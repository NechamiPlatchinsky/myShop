using Entities;
using Microsoft.AspNetCore.Mvc;
using Reposetories;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace myShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductReposetory productReposetory;
        public ProductController(IProductReposetory _productReposetory)
        {
            productReposetory = _productReposetory;
        }
        // GET: api/<ProductController>
        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            return await productReposetory.getAllProduct();
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<Product> Get(int id)
        {
            return await productReposetory.getProductById(id);
        }

        // POST api/<ProductController>
        //[HttpPost]
        //public void Post([FromBody] Product newProduct)
        //{
        //    //await productReposetory.addProduct(newProduct);
        //    //return CreatedAtAction(nameof(Get), new { id = newProduct.Id }, newProduct);
        //}

        // PUT api/<ProductController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] Product updateProduct)
        //{
        //    //await productReposetory.updateProduct(id, updateProduct);
        //}

        //// DELETE api/<ProductController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
