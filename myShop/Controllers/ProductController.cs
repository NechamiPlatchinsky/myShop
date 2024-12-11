using AutoMapper;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Reposetories;
using Services;
using DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace myShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductServices productServices;
        IMapper _mapper;
        public ProductController(IProductServices _productServices ,IMapper mapper)
        {
            productServices = _productServices;
            _mapper = mapper;
        }
        // GET: api/<ProductController>
        [HttpGet]
        public async Task<IEnumerable<ProductDTO>> Get()
        {
            IEnumerable<Product> products =await productServices.getAllProduct();
            IEnumerable<ProductDTO> productsDTO = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(products);
            return productsDTO;

        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<ProductDTO> Get(int id)
        {
            Product product = await productServices.getProductById(id);
            ProductDTO productDTO = _mapper.Map<Product, ProductDTO>(product);
            return productDTO;
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
