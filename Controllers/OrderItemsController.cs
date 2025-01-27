using FoodBooking4.Models;
using FoodBooking4.Models.LoginDto;
using FoodBooking4.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodBooking4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = UserRoles.User)]
    [AllowAnonymous]
    public class OrderItemsController : ControllerBase
    {
        private readonly IOrderItem _OrdItem;
        public OrderItemsController(IOrderItem orderItem)
        {
            _OrdItem = orderItem;
        }
        [HttpPost("Add orderitem")]
        public async Task<IActionResult> AddOrderItemAsync(OrderItemDto orderItem)
        {
            await _OrdItem.AddOrderItemAsync(orderItem);
            return Ok(orderItem);
        }
        [HttpGet("All orderitems")]
        public async Task<IActionResult> GetAllOrderItems()
        {
            var result = await _OrdItem.GetAllOrderItems();
            return Ok(result);
        }
        [HttpDelete("Del Res")]

        public async Task<IActionResult> RemoveOrderItemAsync(int id)
        {
            await _OrdItem.RemoveOrderItemAsync(id);
            return Ok();
        }
    }
}
