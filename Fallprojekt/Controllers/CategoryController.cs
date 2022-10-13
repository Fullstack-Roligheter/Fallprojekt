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

        [HttpPost("CreateCategory")]
        public IActionResult AddCategory(CreateCategoryDTO input)
        {
            try
            {
                if (UserService.Instance.CheckUserId(input.UserId))
                {
                    CategoryService.Instance.CreateCategory(input);
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

        [HttpDelete("DeleteCategory")]
        public IActionResult DeleteCategory([FromQuery]DeleteCategoryDTO input)
        {
            try
            {
                if (UserService.Instance.CheckUserId(input.UserId))
                {
                    CategoryService.Instance.DeleteCategory(input);
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

        [HttpGet("GetCategoriesForUser")]
        public IActionResult GetCategoriesForUser([FromQuery]GetCategoriesDTO input)
        {
            try
            {
                if (UserService.Instance.CheckUserId(input.UserId))
                {
                    var result = CategoryService.Instance.GetCategoriesForUser(input);
                    return Ok(result);
                }
                return StatusCode(404);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500);
            }
        }

        [HttpGet("GetUserCreatedCategories")]
        public IActionResult GetUserCreatedCategories([FromQuery] GetCategoriesDTO input)
        {
            try
            {
                if (UserService.Instance.CheckUserId(input.UserId))
                {
                    var result = CategoryService.Instance.GetCategoriesForUseradasd(input);
                    return Ok(result);
                }
                return StatusCode(404);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500);
            }
        }

        [HttpPut("EditCategory")]
        public IActionResult EditDebit(EditCategoryDTO input)
        {
            try
            {
                var result = UserService.Instance.CheckUserId(input.UserId);
                input.CategoryName ??= "Default";
                if (result)
                {
                    CategoryService.Instance.EditCategory(input);
                    return Ok();
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
