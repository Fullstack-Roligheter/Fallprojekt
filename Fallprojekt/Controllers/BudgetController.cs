using Microsoft.AspNetCore.Mvc;
using Service;
using Service.DTOs;

namespace Fallprojekt.Controllers
{
    [Route("api/budget")]
    [ApiController]
    public class BudgetController : ControllerBase
    {
        [HttpPost("/ListAllBudgetForSpecificUser")]
        public IActionResult ListAllListUserBudgets(UserIdDTO input)
        {
            //try
            //{
            //    return Ok(BudgetService.Instance.ListUserBudgets(input));
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest(ex.Message);
            //}
            try
            {
                return Ok(BudgetService.Instance.ListUserBudgets(input));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500);
            }
        }

        [HttpGet("/ListAllBudgetForSpecificUser")]
        public IActionResult GetUserIdFromQuery([FromQuery]UserIdDTO input)
        {
            try
            {
                return Ok(BudgetService.Instance.ListUserBudgets(input));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}