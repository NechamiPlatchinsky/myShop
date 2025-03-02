using Microsoft.AspNetCore.Mvc;
using Entities;
using Reposetories;
using Services;
using System.Collections.Generic;
using DTO;
using AutoMapper;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace myShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryServices categoryServices;
        IMapper _mapper;
        public CategoryController(ICategoryServices _ICategoryServices, IMapper mapper)
        {
            categoryServices = _ICategoryServices;
            _mapper = mapper;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<IEnumerable<CategoryDTO>> Get()
        {
            IEnumerable <Category> categories = await categoryServices.getAllCategories();
            IEnumerable<CategoryDTO> categoriesDTO = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(categories);
            return categoriesDTO;
        }        
    }
}
