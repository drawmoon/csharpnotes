using AspNetCoreJsonPatch.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using RestApiJsonPatch.Models;
using System;

namespace RestApiJsonPatch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        [HttpPatch]
        public IActionResult Patch([FromBody] JsonPatchDocument<Order> orderPatch)
        {
            var order = new Order
            {
                Name = $"Or_{Guid.NewGuid()}",
                OrderDetails = new[]
                {
                    new OrderDetail
                    {
                        Name = "珍珠奶茶A"
                    }
                }
            };

            orderPatch.ApplyTo(order);

            return Ok(order);
        }
    }
}
