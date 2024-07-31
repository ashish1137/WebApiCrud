using ecommerce.Model;
using ecommerce.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_orderService.GetAllOrders());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var order = _orderService.GetOrderByID(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpPost]
        public IActionResult Post(ModifyOrder orderObject)
        {
            var order = _orderService.AddOrder(orderObject);

            if (order == null)
            {
                return BadRequest();
            }

            return Ok(new
            {
                message = "Order Created Successfully!!!",
                id = order!.Id
            });
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] ModifyOrder orderObject)
        {
            var order = _orderService.UpdateOrder(id, orderObject);
            if (order == null)
            {
                return NotFound();
            }

            return Ok(new
            {
                message = "Order Updated Successfully!!!",
                id = order!.Id
            });
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            if (!_orderService.DeleteOrderByID(id))
            {
                return NotFound();
            }

            return Ok(new
            {
                message = "Order Deleted Successfully!!!",
                id = id
            });
        }
    }
}
