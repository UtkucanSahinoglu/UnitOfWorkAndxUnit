using Microsoft.AspNetCore.Mvc;
using UnitOfWorkAndxUnit.Application.DTOs;
using UnitOfWorkAndxUnit.Application.Interfaces;
using UnitOfWorkAndxUnit.Domain.Entities;

namespace UnitOfWorkAndxUnit.Api.Controllers
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
        public async Task<IActionResult> GetAll()
        {
            var orders = await _orderService.GetAllOrdersAsync();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            var order = await _orderService.GetOrderWithProductsAsync(id);
            if (order == null) return NotFound();
            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] OrderCreateDto dto)
        {
            var order = new Order
            {
                CustomerName = dto.CustomerName,
                TotalAmount = dto.TotalAmount
            };

            await _orderService.AddOrderAsync(order, dto.ProductIds);
            return Ok(order);
        }
    }
}
