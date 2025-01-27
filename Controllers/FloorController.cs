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
    [Authorize(Roles = UserRoles.Admin)]

    public class FloorController : ControllerBase
    {
        private readonly IFloor _floor;
        public FloorController(IFloor floor)
        {
            _floor = floor;
        }
        [HttpPost("Add Floor")]
        public async Task <IActionResult> AddFloorsAsync(Floor floor)
        {
            await _floor.AddFloorsAsync(floor);
            return Ok(floor);
        }
        [HttpGet("All Floor")]
        public async Task<IActionResult> GetAllFloors()
        {
            var result = await _floor.GetAllFloors();
            return Ok(result);
        }
        [HttpDelete("Del Floor")]
        public async Task<IActionResult> RemoveFloorsAsync(int id)
        {
            await _floor.RemoveFloorsAsync(id);
            return Ok();
        }
        [HttpPut("Update Floor")]
        public async Task<IActionResult> UpdateFloorsAsync(Floor floor)
        {
            var result = _floor.UpdateFloorsAsync(floor);
            return Ok(result);
        }
    }
}
