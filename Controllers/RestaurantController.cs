using FoodBooking4.Models;
using FoodBooking4.Models.LoginDto;
using FoodBooking4.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace FoodBooking4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = UserRoles.Admin)]

    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurant _res;
        public RestaurantController(IRestaurant restaurant)
        {
            _res = restaurant;
        }
        [HttpPost("Add res")]
        public async Task<IActionResult> AddResAsync(Restaurant restaurant)
        {
            await _res.AddResAsync(restaurant);
            return Ok(restaurant);
        }
        [HttpGet("All res")]
        public async Task<IActionResult> GetAllRes()
        {
            var result = await _res.GetAllRes();
            return Ok(result);
        }
        [HttpDelete("Del Res")]
        public async Task<IActionResult> RemoveResAsync(int id)
        {

            await _res.RemoveResAsync(id);
            return Ok();
        }
        [HttpPut("Update Res")]
        public async Task<IActionResult> UpdateResAsync( Restaurant restaurant)
        {
            var result = _res.UpdateResAsync(restaurant);
            return Ok(result);
        }
    }
}
