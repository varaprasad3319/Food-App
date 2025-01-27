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
    public class CombosandItemsController : ControllerBase
    {
        private readonly ICombosandItems _combosandItems;
        public CombosandItemsController(ICombosandItems combosandItems)
        {
            _combosandItems = combosandItems;
        }
        [HttpPost("Add combo")]
        public async Task<IActionResult> AddComboorItemAsync(CombosandItems combosandItems)
        {

            await _combosandItems.AddComboorItemAsync(combosandItems);
            return Ok(combosandItems);
        }

        [AllowAnonymous]
        [HttpGet("All Combo")]

        public async Task<IActionResult> GetAllComboorItem()
        {
            var result = await _combosandItems.GetAllComboorItem();
            return Ok(result);
        }
        [HttpDelete("Del Combo")]

        public async Task<IActionResult> RemoveComboorItemAsync(int id)
        {
            await _combosandItems.RemoveComboorItemAsync(id);
            return Ok();
        }
        [HttpPut("Update Combo")]

        public async Task<IActionResult> UpdateComboorItemAsync(CombosandItems combosandItems)
        {
            var result = _combosandItems.UpdateComboorItemAsync(combosandItems);
            return Ok(result);
        }
        [HttpGet("GetAllComboListItemsById")]
        public Task<IEnumerable<ListOfComboItems>> GetAllComboListItemsById(int id)
        {
            return _combosandItems.GetAllComboListItemsById(id);
        }
    }
}
