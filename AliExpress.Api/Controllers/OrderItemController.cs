using AliExpress.Application.IServices;
using Microsoft.AspNetCore.Mvc;

namespace AliExpress.Api.Controllers
{
    public class OrderItemController : Controller { 
    private readonly IorderItemService _orderItemService;

    public OrderItemController(IorderItemService orderItemService)
    {
            _orderItemService = orderItemService;
    }


        [HttpDelete("orderItem/{orderItemId}")]
        public async Task<IActionResult> DeleteOrderItem( int orderItemId)
        {
            if (orderItemId == null)
            {
                return NotFound();
            }

            await _orderItemService.DeleteOrderItemAsync(orderItemId);
            return Ok();
        }
    }
}
