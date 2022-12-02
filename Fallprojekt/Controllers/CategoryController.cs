using Microsoft.AspNetCore.Mvc;
using Service.DTOs;
using Service.Interfaces;

namespace Fallprojekt.Controllers;

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
    public async Task<IActionResult> AddCategory(CreateCategoryDTO input)
    {
        try
        {
            if (! await _userService.CheckUserId(input.UserId))
            {
                return StatusCode(404);
            }
            _categoryService.CreateCategory(input);
            return Ok();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500);
        }
    }

    [HttpDelete("DeleteCategory")]
    public async Task<IActionResult> DeleteCategory([FromQuery]DeleteCategoryDTO input)
    {
        try
        {
            if (! await _userService.CheckUserId(input.UserId))
            {
                return StatusCode(404);
            }
            _categoryService.DeleteCategory(input);
            return Ok();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500);
        }
    }

    [HttpGet("GetCategoriesForUser")]
    public async Task<IActionResult> GetCategoriesForUser([FromQuery]GetCategoriesDTO input)
    {
        try
        {
            if (! await _userService.CheckUserId(input.UserId))
            {
                return StatusCode(404);
            }
            var result = _categoryService.GetCategoriesForUser(input);
            return Ok(result);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500);
        }
    }

    [HttpGet("GetUserCreatedCategories")]
    public async Task<IActionResult> GetUserCreatedCategories([FromQuery] GetCategoriesDTO input)
    {
        try
        {
            if (! await _userService.CheckUserId(input.UserId))
            {
                return StatusCode(404);
            }
            var result = _categoryService.GetUserCreatedCategories(input);
            return Ok(result);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500);
        }
    }

    [HttpPut("EditCategory")]
    public async Task<IActionResult> EditDebit(EditCategoryDTO input)
    {
        try
        {
            if (! await _userService.CheckUserId(input.UserId))
            {
                return NotFound("User not found");
            }
            _categoryService.EditCategory(input);
            return Ok();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500);
        }
    }
}