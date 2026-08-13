using _06Aug_2026.Models;
using _06Aug_2026.Repository;
using Microsoft.AspNetCore.Mvc;

namespace _06Aug_2026.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService service;

        public OrdersController(IOrderService service)
        {
            this.service = service;
        }
        
        [HttpGet]
        public IActionResult GetOrders()
        {
            return Ok(service.GetOrders());
        }

        [HttpGet("{id}")]
        public IActionResult GetOrderById(int id)
        {
            var order = service.GetOrderById(id);

            if (order == null)
            {
                return NotFound("Order Not Found");
            }

            return Ok(order);
        }

        [HttpPost]
        public IActionResult AddOrder(Order order)
        {
            if (ModelState.IsValid)
            {
                service.AddOrder(order);
                return Ok("Order Added Successfully");
            }

            return BadRequest(ModelState);
        }

        //modify order details from order table based on OrderId
        [HttpPut]
        public IActionResult UpdateOrder(Order order)
        {
            if (ModelState.IsValid)
            {
                service.UpdateOrder(order);
                return Ok("Order Updated Successfully");
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            var order = service.GetOrderById(id);

            if (order == null)
            {
                return NotFound("Order Not Found");
            }

            service.DeleteOrder(id);
            return Ok("Order Deleted Successfully");
        }
    }
}
