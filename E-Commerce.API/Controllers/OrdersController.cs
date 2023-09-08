using E_Commerce.API.Models.DTO;
using E_Commerce.API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace E_Commerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrdersController(IOrderService orderService)
        {
            this.orderService = orderService;
        }
        [HttpPost]
        [Route("Order")]
        public async Task<IActionResult> Create([FromBody] OrderRequestDto orderRequest)
        {
            var claims = User.Claims.Where(x => true).ToList();
            var userId = User.Claims.First(i => i.Type == ClaimTypes.NameIdentifier).Value;
            var response = await orderService.CreateAsync(orderRequest,userId);

            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var response = await orderService.GetByIdAsync(id);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}
