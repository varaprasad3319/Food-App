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

    public class ListOfComboItemsController : ControllerBase
    {
        private readonly IListOfComboItems _listOfComboItems;
        private readonly ILogger<ListOfComboItemsController> _logger;
        public ListOfComboItemsController(IListOfComboItems listOfComboItems, ILogger<ListOfComboItemsController> logger)
        {
            _listOfComboItems = listOfComboItems ;
            _logger = logger;
        }
        [HttpPost("Add items")]
        public async Task<IActionResult> AddIteminComboAsync(ListOfComboItems listOfComboItems)
        {
            try
            {
                await _listOfComboItems.AddIteminComboAsync(listOfComboItems);
                return Ok(listOfComboItems);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("All items")]

        public async Task<IActionResult> GetAllIteminCombo()
        {
            try
            {
                var result = await _listOfComboItems.GetAllIteminCombo();
                _logger.LogInformation("the Item is {item}", result);
                return Ok(result);
            }
            catch(Exception ex) 
            {
                _logger.LogError($"{ex.Message}");
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("Del items")]
        public async Task<IActionResult> RemoveIteminComboAsync(int id)
        {
            try
            {
                await _listOfComboItems.RemoveIteminComboAsync(id);
                return Ok();
            }
            catch (Exception ex) 
            { 
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("Update items")]

        public async Task<IActionResult> UpdateIteminComboAsync( ListOfComboItems listOfComboItems)
        {
            try
            {
                var result = _listOfComboItems.UpdateIteminComboAsync(listOfComboItems);
                return Ok(result);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
        
    }
}
