using Microsoft.AspNetCore.Mvc;
using Services;
using Entities;
using AutoMapper;
using DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace myShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IOrderServices orderService;
        IMapper _mapper;
        public OrderController(IOrderServices IOrderServices, IMapper mapper)
        {
            orderService = IOrderServices;
            _mapper = mapper;
        }

        // GET: api/<OrderController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public async Task<OrderDTO> Get(int id)
        {
            Order order = await orderService.getOrderById(id);
            OrderDTO orderDTO = _mapper.Map<Order, OrderDTO>(order);
            return orderDTO;
        }

        // POST api/<OrderController>
        [HttpPost]
        public async Task<ActionResult<Order>> Post([FromBody] OrderPostDTO newOrder)
        {
            Order order = _mapper.Map<OrderPostDTO, Order>(newOrder);
            var a = await orderService.addOrder(order);
            OrderNewDTO orderNew = _mapper.Map<Order, OrderNewDTO>(a);
            if (orderNew != null)
                return CreatedAtAction(nameof(Get), new { id = a.OrderId }, orderNew);
            return BadRequest();
        }
    }
}
