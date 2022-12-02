using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs;
using Service.Interfaces;

namespace Fallprojekt.Controllers;

[Route("api/user")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly ILogger<UserController> _logger;

    public UserController(IUserService userService, ILogger<UserController> logger)
    {
        _userService = userService;
        _logger = logger;
    }
        
    [HttpPost("Login")]
    public IActionResult UserLogin(LoginDTO login)
    {
        try
        {
            var result = _userService.LogIn(login);

            if (result == null)
            {
                return StatusCode(401);
            }
            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, $"CONTROLLER HERE: {ex.Message}");
            return StatusCode(500);
        }
    }

    [HttpPost("Register")]
    public IActionResult UserRegister(RegisterDTO reg)
    {
        try
        {
            var r = new Regex(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$ %^&*-]).{4,}$");

            if (!r.Match(reg.Password).Success) return BadRequest("Invalid Password");

            if (_userService.CheckEmail(reg)) return StatusCode(409, "Account already exists");

            _userService.UserRegister(reg);
            return Ok();
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
            return StatusCode(500);
        }
    }

    [HttpPost("User")]
    public IActionResult UpdateUserInfo(UserDTO user)
    {
        try
        {
            var r = new Regex(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$ %^&*-]).{4,}$");

            if (!r.Match(user.Password).Success)
            {
                return BadRequest("Invalid Password");
            }

            if (!_userService.CheckUserId(user.UserId))
            {
                return NotFound("User not Found!");
            }

            _userService.UpdateUserInfo(user);
            return Ok();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return StatusCode(500);
        }
    }
}