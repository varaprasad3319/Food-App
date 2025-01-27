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

    public class FoodCourtController : ControllerBase
    {
        private readonly IFoodCourt _foodcourt;
        public FoodCourtController(IFoodCourt foodcort)
        {
            _foodcourt = foodcort;
        }
        [HttpPost("Add FC")]
        public async Task<IActionResult> AddFoodCourtAsync(FoodCourt foodCourt)
        {
            await _foodcourt.AddFoodCourtAsync(foodCourt);
            return Ok(foodCourt);
        }

        [HttpDelete("Delete FC")]
        public async Task<IActionResult> RemoveFoodCourtAsync(int id)
        {
            await _foodcourt.RemoveFoodCourtAsync(id);
            return Ok();
        }
        [HttpGet("All FC")]
        public async Task<IActionResult> GetAllFoodCourts()
        {
            var result = await _foodcourt.GetAllFoodCourts();
            return Ok(result);
        }
        [HttpPut("UpdateFC")]
        public async Task<IActionResult> UpdateFoodCourtAsync( FoodCourt foodCourt)
        {
            var result = _foodcourt.UpdateFoodCourtAsync( foodCourt);
            return Ok(result);
        }
        
    }
}
