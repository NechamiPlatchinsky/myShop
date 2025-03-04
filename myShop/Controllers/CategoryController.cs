using Microsoft.AspNetCore.Mvc;
using Entities;
using Reposetories;
using Services;
using System.Collections.Generic;
using DTO;
using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace myShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryServices categoryServices;
        IMapper _mapper;
        IMemoryCache _cache;
        public CategoryController(ICategoryServices _ICategoryServices, IMapper mapper, IMemoryCache cache)
        {
            categoryServices = _ICategoryServices;
            _mapper = mapper;
            _cache = cache;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get()
        {
            if (!_cache.TryGetValue("categories", out IEnumerable<Category> categories))
            {
                categories = await categoryServices.getAllCategories();
                _cache.Set("categories", categories, TimeSpan.FromMinutes(30));
            }
            IEnumerable<CategoryDTO> categoriesDTO = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(categories);
            if (categoriesDTO != null)
                return Ok(categoriesDTO);
            return NotFound();

        }        
    }
}
