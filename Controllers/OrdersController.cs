using FoodBooking4.Models;
using FoodBooking4.Models.LoginDto;
using FoodBooking4.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FoodBooking4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = UserRoles.User)]
    [AllowAnonymous]
    public class OrdersController : ControllerBase
    {
        private readonly IOrders _orders;
        private readonly ICombosandItems _combosandItems;
        public OrdersController(IOrders orders, ICombosandItems combosandItems)
        {
            _orders = orders;
            _combosandItems = combosandItems;
        }
        [HttpGet("All Combo")]

        public async Task<IActionResult> GetAllComboorItem()
        {
            var result = await _combosandItems.GetAllComboorItem();
            return Ok(result);
        }

        [HttpPost("Add order")]
        public async Task<IActionResult> AddOrdersAsync([FromBody] OrdersDto ordersDto)
        {
            var createdOrder = await _orders.AddOrdersAsync(ordersDto);
            return CreatedAtAction(nameof(GetOrderById), new { id = createdOrder.OrderId }, new { OrderId = createdOrder.OrderId });
        }
        [HttpGet("All orders")]
        public async Task<IActionResult> GetAllOrders()
        {
            var result = await _orders.GetAllOrders();
            return Ok(result);
        }

        [HttpGet("GetAllOrdersByID")]

        public async Task<Orders> GetOrderById(int id)
        {
            return await _orders.GetOrderByOrderId(id);
        }

        [HttpDelete("Del Res")]
        public async Task<IActionResult> RemoveOrderAsync(int id)
        {
            await _orders.RemoveOrderAsync(id);
            return Ok();
        }
    }
}