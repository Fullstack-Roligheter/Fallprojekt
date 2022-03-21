using Microsoft.AspNetCore.Mvc;
using Service;
using Service.DTOs;

namespace Fallprojekt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        [HttpGet("category")]
        public IActionResult ListAllCategories()
        {
            try
            {
                return Ok(CategoryService.Instance.ListAllCategory());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("categoryBudget")]
        public IActionResult ListAllCategoryMatchBudget([FromQuery] BudgetNameDTO input)
        {
            try
            {
                return Ok(CategoryService.Instance.ListAllCategoryMatchBudget(input));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddNewCategory")]
        public IActionResult AddNewCategory(NewCategoryDTO input)
        {
            try
            {
                if (!ValidationService.Instance.ValidateUser(input.UserId))
                {
                    return StatusCode(418, "ValidateUser failed...");
                }
                if (!ValidationService.Instance.ValidateBudget(input.UserId, input.BudgetId))
                {
                    return StatusCode(418, "ValidateBudget failed...");
                }

                CategoryService.Instance.AddNewCategory(input);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(418, ex);
            }
        }
    }
}
