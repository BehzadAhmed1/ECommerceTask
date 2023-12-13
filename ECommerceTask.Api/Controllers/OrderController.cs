using ECommerceTask.Api.DTOs;
using ECommerceTask.Domain.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceTask.Api.Controllers
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

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] OrderDto orderDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var orderId = await _orderService.CreateOrderAsync(orderDto);
                return Ok(orderId);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex}");
            }
        }

    }
}
