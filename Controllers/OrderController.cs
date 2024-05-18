using Microsoft.AspNetCore.Mvc;
using TiendaDeFrutas.Dto;
using TiendaDeFrutas.Entities;
using TiendaDeFrutas.Services.Contracts;

namespace TiendaDeFrutas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService) => _orderService = orderService;

        [HttpPost("createOrderFruits")]
        public async Task<ActionResult<Fruit>> CreateOrder(List<OrderDto> orderDto)
        {
            if (orderDto is null)
            {
                return NotFound("Validate information, it can't be null");
            }

            return Ok(await _orderService.CreateOrder(orderDto));
        }
    }


}
