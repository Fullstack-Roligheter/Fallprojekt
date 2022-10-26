using Microsoft.AspNetCore.Mvc;
using Service;
using Service.DTOs;
using Service.Interfaces;

namespace Fallprojekt.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IUserService _userService;
        public CategoryController(ICategoryService categoryService, IUserService userService)
        {
            _categoryService = categoryService;
            _userService = userService;
        }

        [HttpPost("CreateCategory")]
        public IActionResult AddCategory(CreateCategoryDTO input)
        {
            try
            {
                if (_userService.CheckUserId(input.UserId))
                {
                    _categoryService.CreateCategory(input);
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
                if (_userService.CheckUserId(input.UserId))
                {
                    _categoryService.DeleteCategory(input);
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
                if (_userService.CheckUserId(input.UserId))
                {
                    var result = _categoryService.GetCategoriesForUser(input);
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
                if (_userService.CheckUserId(input.UserId))
                {
                    var result = _categoryService.GetUserCreatedCategories(input);
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
                var result = _userService.CheckUserId(input.UserId);
                input.CategoryName ??= "Default";
                if (result)
                {
                    _categoryService.EditCategory(input);
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
