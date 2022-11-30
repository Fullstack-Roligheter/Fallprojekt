using Microsoft.AspNetCore.Mvc;
using Castle.Core.Internal;
using Service.Interfaces;

namespace Fallprojekt.Controllers;

[Route("api/debug")]
[ApiController]
public class DebugController : ControllerBase
{
    private readonly ICategoryService _categoryService;
    private readonly IUserService _userService;
    private readonly IDebitService _debitService;
    public DebugController(ICategoryService categoryService, IUserService userService, IDebitService debitService)
    {
        _categoryService = categoryService;
        _userService = userService;
        _debitService = debitService;
    }


    [HttpGet("GetAllUsers")]
    public IActionResult GetAllUsers()
    {
        return Ok(_userService.GetAllUsers());
    }


    [HttpGet("GetAllDebits")]
    public IActionResult GetAllDebits()
    {
        return Ok(_debitService.GetAll());
    }


    [HttpGet("GetDebitListForUser")]
    public IActionResult GetExpensesListForUser(Guid userId)
    {
        return Ok(_debitService.GetAllWithUserId(userId));
    }


    [HttpGet("ListAllCategories")]
    public IActionResult ListAllCategories()
    {
        try
        {
            var result = _categoryService.ListAllCategories();
            if (result.IsNullOrEmpty())
            {
                return NotFound();
            }
            return Ok(result);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return BadRequest();
        }
    }
}