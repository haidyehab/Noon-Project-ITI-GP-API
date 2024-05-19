using AliExpress.Application.IServices;
using AliExpress.Application.Services;
using AliExpress.Context;
using AliExpress.Dtos.Order;
using AliExpress.Models;
using AliExpress.Models.Orders;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace AliExpress.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly AliExpressContext _context;
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        private readonly ICartService _cartService;

        public OrderController(IOrderService orderService, ICartService cartService, AliExpressContext context)
        {
            _orderService = orderService;
            _cartService = cartService;
            _context = context;
        }
        [HttpPost]
        public async Task<ActionResult<OrderReturnDto>> CreateOderAsync(OrderDto orderDto)
        {
            if(ModelState.IsValid)
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var mappedOrder = await _orderService.CreateOrderAsync(orderDto.CartId, orderDto.DeliveryMethodId, userId);

                await _cartService.DeleteCartDtoAsync(mappedOrder.AppUser.Cart.CartId);
                var order = await _context.Orders
                    .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Product)
                    .ThenInclude(i => i.Images)// Include the related Product entity
                    .Include(o => o.DeliveryMethod)
                    .Include(o => o.AppUser)
                    .Where(o => o.AppUserId == userId)
                    .OrderByDescending(o => o.CreatedAt)
                    .FirstOrDefaultAsync();

                if (orderDto.subtotal != null)
                {
                    order.Subtotal = orderDto.subtotal.Value; // Explicitly accessing the value
                    _context.SaveChanges();
                }


                return Ok(mappedOrder);
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GetOrdersAsync()
        {
           var orders= await _orderService.GetAllOrdersAsync();
            if(orders != null)
            {
                return Ok(orders);
            }
           return NoContent();
        }




      [HttpDelete("delete/{orderId}")]
    public async Task<ActionResult> DeleteOrderAsync(int orderId)
    {
        await _orderService.DeleteOrderAsync(orderId);
        return NoContent();
    }
        [HttpGet("delivery-methods")]
        public async Task<ActionResult<IEnumerable<DeliveryMethod>>> GetDeliveryMethods()
        {
            var deliveryMethods = await _orderService.GetDeliveryMethods();
            return Ok(deliveryMethods);
        }


        //[HttpGet("user/{userId}")]
        [HttpGet("user")]
        public async Task<ActionResult<OrderReturnDto>> GetOrderByUserIdAsync()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var orderDto = await _orderService.GetOrderByUserIdAsync(userId);
            return Ok(orderDto);
        }

        
        [HttpGet("last")]
        public async Task<ActionResult<OrderReturnDto>> GetOrderLastAsync()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var orderDto = await _orderService.GetOrderLastAsync(userId);
            return Ok(orderDto);
        }

        [HttpPut("update/{orderId}")]
        public async Task<ActionResult> UpdateOrderAsync(int orderId, OrderReturnDto orderReturnDto)
        {
            try
            {
                await _orderService.UpdateOrderAsync(orderId, orderReturnDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
