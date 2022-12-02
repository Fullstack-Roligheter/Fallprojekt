using Microsoft.AspNetCore.Mvc;
using Castle.Core.Internal;
using Service.Interfaces;
using Microsoft.Extensions.Logging;

namespace Fallprojekt.Controllers;

[Route("api/debug")]
[ApiController]
public class DebugController : ControllerBase
{
    private readonly ICategoryService _categoryService;
    private readonly IUserService _userService;
    private readonly IDebitService _debitService;
    private readonly ILogger<DebugController> _logger;
    public DebugController(ICategoryService categoryService, IUserService userService, IDebitService debitService, ILogger<DebugController> logger)
    {
        _categoryService = categoryService;
        _userService = userService;
        _debitService = debitService;
        _logger = logger;
    }


    [HttpGet("GetAllUsers")]
    public async Task<IActionResult> GetAllUsers()
    {
        try
        {
            return Ok(await _userService.GetAllUsers());
        }
        catch (Exception ex)
        {
            _logger.LogWarning("Error Caught in GetAllUsers Controller:\n {exception}", ex);
            return StatusCode(500, $"{ex.Message}");
        }
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