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
        public IActionResult ListAllCategoryMatchBudget([FromQuery]BudgetNameDTO input)
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


    }
}
