using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.DTOs;
using Service.Interfaces;

namespace Fallprojekt.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
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
                Console.WriteLine(ex.Message);
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
    }
}