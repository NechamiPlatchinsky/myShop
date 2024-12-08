using Microsoft.AspNetCore.Mvc;
using Services;
using Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace myShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IOrderServices orderService;

        public OrderController(IOrderServices IOrderServices)
        {
            orderService=IOrderServices;
        }

        // GET: api/<OrderController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public async Task<Order> Get(int id)
        {
            return await orderService.getOrderById(id);
        }

        // POST api/<OrderController>
        [HttpPost]
        public async Task<ActionResult<Order>> Post([FromBody] Order newOrder)
        {
            await orderService.addOrder(newOrder);
            return CreatedAtAction(nameof(Get), new { id = newOrder.OrderId }, newOrder);
        }
        
        // PUT api/<OrderController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<OrderController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
