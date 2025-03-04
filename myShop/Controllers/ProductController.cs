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
        public async Task<ActionResult<IEnumerable<ProductDTO>>> Get([FromQuery] int? position, [FromQuery] int? skip, [FromQuery] string? desc, [FromQuery] int? minPrice, [FromQuery] int? maxPrice, [FromQuery] int?[] categoryIds)
        {
            //int a = 2;
            //int b = a / 0;
            IEnumerable<Product> products = await productServices.getAllProduct(position, skip, desc, minPrice, maxPrice, categoryIds);
            IEnumerable<ProductDTO> productsDTO = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(products);
            return Ok(productsDTO);

        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> Get(int id)
        {
            Product product = await productServices.getProductById(id);
            ProductDTO productDTO = _mapper.Map<Product, ProductDTO>(product);
            return Ok(productDTO);
        }

        
    }
}
