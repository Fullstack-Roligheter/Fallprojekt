using Microsoft.AspNetCore.Mvc;
using Service;
using Service.DTOs;

namespace Fallprojekt.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        //        [HttpGet("categoryBudget")]
        //        public IActionResult ListAllCategoryMatchBudget([FromQuery] BudgetNameDTO input)
        //        {
        //            try
        //            {
        //                return Ok(CategoryService.Instance.ListAllCategoryMatchBudget(input));
        //            }
        //            catch (Exception ex)
        //            {
        //                return BadRequest(ex.Message);
        //            }
        //        }

        [HttpPost("AddNewCategory")]
        public IActionResult AddNewCategory(NewCategoryDTO input)
        {
            try
            {
                if (UserService.Instance.CheckUserId(input.UserId))
                {
                    CategoryService.Instance.AddNewCategory(input);
                    return Ok();
                }
                return StatusCode(404);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500);
            }
        }
    }
}
