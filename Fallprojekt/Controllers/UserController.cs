using System.Text.RegularExpressions;
using Castle.Core.Internal;
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
    private readonly Regex _pr = new (@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$ %^&*-]).{4,}$");
    private readonly Regex _er = new (@"(([^<>()\[\]\\.,;:\s@""]+(\.[^<>()\[\]\\.,;:\s@""]+)*)|("".+""))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))");


    public UserController(IUserService userService, ILogger<UserController> logger)
    {
        _userService = userService;
        _logger = logger;
    }

    [HttpPost("Login")]
    public async Task<IActionResult> UserLogin(LoginDTO login)
    {
        try
        {
            if (login.Password == "" || login.Email == "")
            {
                return StatusCode(400);
            }

            var result = await _userService.LogIn(login);

            if (result == null)
            {
                return StatusCode(401);
            }
            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError("\nError Caught in Login:\n {exception}\n", ex);
            return StatusCode(500);
        }
    }

    [HttpPost("Register")]
    public async Task<IActionResult> UserRegister(RegisterDTO reg)
    {
        try
        {
            if (!_pr.Match(reg.Password).Success)
            {
                return BadRequest("Invalid Password");
            }

            if (await _userService.CheckEmail(reg))
            {
                return StatusCode(409, "Account already exists");
            }

            await _userService.UserRegister(reg);
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError("Error Caught in Register:\n {exception}", ex);
            return StatusCode(500);
        }
    }

    [HttpPatch("Update")]
    public async Task<IActionResult> UpdateUserInfo(UserDTO userInfo)
    {
        try
        {
            if (!_pr.Match(userInfo.Password).Success)
            {
                return BadRequest("Invalid Password");
            }

            if (!_er.Match(userInfo.Email).Success)
            {
                return BadRequest("Invalid Email");
            }

            var id = userInfo.UserId;

            var user = await _userService.GetUserWithId(id);
            if (user == null)
            {
                return NotFound("User not Found!");
            }

            await _userService.UpdateUserInfo(user, userInfo);

            var returnUser = new SuccessLoginDTO()
            {
                UserId = userInfo.UserId,
                FirstName = userInfo.FirstName,
                LastName = userInfo.LastName,
                Email = userInfo.Email
            };

            return Ok(returnUser);
        }
        catch (Exception ex)
        {
            _logger.LogError("Error Caught in User:\n {exception}", ex);
            return StatusCode(500);
        }
    }

    [HttpDelete("UserDelete")]
    public async Task<IActionResult> DeleteUser([FromQuery]LoginDTO userInfo)
    {
        try
        {
            if (userInfo.UserId == null || userInfo.Email.IsNullOrEmpty() || userInfo.Password.IsNullOrEmpty())
            {
                return StatusCode(401);
            }

            var id = (Guid)userInfo.UserId;
            var email = userInfo.Email;
            var password = userInfo.Password;

            var user = await _userService.GetUserWithIdAndEmailAndPassword(id, email, password);
            if (user == null)
            {
                return StatusCode(401);
            }

            await _userService.DeleteUser(user);

            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError("Error Caught in UserDelete:\n {exception}", ex);
            return StatusCode(401);
        }
    }
}