using DAL;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.DTOs;
using Service.Interfaces;

namespace Fallprojekt.Controllers
{
    [Route("api/budget")]
    [ApiController]
    public class BudgetController : ControllerBase
    {
        private readonly IBudgetService _budgetService;
        private readonly IUserService _userService;

        public BudgetController(IBudgetService budgetService, IUserService userService)
        {
            _budgetService = budgetService;
            _userService = userService;
        }

        [HttpPost("CreateBudget")]
        public IActionResult CreateBudget(CreateBudgetDTO input)
        {
            try
            {
                var result = _userService.CheckUserId(input.UserId);
                if (result)
                {
                    _budgetService.CreateBudget(input);
                    return StatusCode(201);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpDelete("DeleteBudget")]
        public IActionResult DeleteBudget([FromQuery] DeleteBudgetDTO input)
        {
            try
            {
                var result = _userService.CheckUserId(input.UserId);
                if (!result) return NotFound();
                _budgetService.DeleteBudget(input);
                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpPut("EditBudget")]
        public IActionResult EditBudget(EditBudgetDTO input)
        {
            try
            {
                var result = _userService.CheckUserId(input.UserId);
                if (!result) return NotFound();
                _budgetService.EditBudget(input);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpGet("GetBudgetsForUser")]
        public IActionResult GetBudgetsForUser([FromQuery] UserIdDTO input)
        {
            try
            {
                var result = _userService.CheckUserId(input.UserId);
                if (result)
                {
                    return Ok(_budgetService.GetBudgetsForUser(input));
                }
                return NotFound("User not found");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500);
            }
        }
    }
}