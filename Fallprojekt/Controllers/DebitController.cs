using Microsoft.AspNetCore.Mvc;
using Service.DTOs;
using Service.Interfaces;

namespace Fallprojekt.Controllers;

[Route("api/debit")]
[ApiController]
public class DebitController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IDebitService _debitService;

    public DebitController(IUserService userService, IDebitService debitService)
    {
        _userService = userService;
        _debitService = debitService;
    }

    [HttpGet("GetDebitListForUser")]
    public async Task<IActionResult> GetExpensesListForUser([FromQuery]UserIdDTO input)
    {
        try
        {
            var result = _debitService.GetAllWithUserId(input.UserId);
            return Ok(result);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return StatusCode(500);
        }
    }

    [HttpPost("CreateDebit")]
    public async Task<IActionResult> CreateDebit(CreateDebitDTO createDebit)
    {
        try
        {
            _debitService.CreateDebit(createDebit);
            return Ok();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return StatusCode(500);
        }
    }

    [HttpGet("GetDebitsForBudget")]
    public async Task<IActionResult> GetDebitsForBudget([FromQuery]GetDebitsDTO input)
    {
        try
        {
            var result = _debitService.GetDebitsForBudget(input);
            return Ok(result);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500);
        }
    }

    [HttpDelete("DeleteDebit")]
    public async Task<IActionResult> DeleteDebit(Guid userId, Guid debitId)
    {
        try
        {
            if (! await _userService.CheckUserId(userId))
            {
                return NotFound("User not found");
            }
            _debitService.DeleteDebit(debitId);
            return Ok();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return StatusCode(500);
        }
    }

    [HttpGet("GetDebitsForCategory")]
    public async Task<IActionResult> GetDebitsForCategory([FromQuery]GetDebitsDTO input)
    {
        try
        {
            if (! await _userService.CheckUserId(input.UserId))
            {
                return NotFound("User not found");
            }
            return Ok(_debitService.GetDebitsForCategory(input));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500);
        }
    }

    [HttpPut("EditDebit")]
    public async Task<IActionResult> EditDebit(EditDebitDTO input)
    {
        try
        {
            if (! await _userService.CheckUserId(input.UserId))
            {
                return NotFound("User not found");
            }
            _debitService.EditDebit(input);
            return Ok();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(500);
        }
    }
}