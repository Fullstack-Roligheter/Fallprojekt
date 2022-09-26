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

        [HttpGet("/ListAllBudgetInfosForSpecificUser/{userId}")]
        public IActionResult ListAllBudgetInfosForSpecificUser(int userId)
        {
            try
            {
                return Ok(BudgetService.Instance.ListUserBudgetsInfo(userId));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500);
            }
        }

        [HttpPost("/AddBudget")]
        public IActionResult AddBudget(AddBudgetDTO input)
        {
            try
            {
                BudgetService.Instance.AddBudget(input);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}