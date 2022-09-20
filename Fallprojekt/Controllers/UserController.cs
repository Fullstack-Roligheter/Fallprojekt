using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.DTOs;

namespace Fallprojekt.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost("Login")]
        public IActionResult UserLogin(LoginDTO login)
        {
            try
            {
                var result = UserService.Instance.LogIn(login);

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
                if (UserService.Instance.CheckEmail(reg))
                {
                    return StatusCode(409, "Account already exists");
                }
                UserService.Instance.UserRegister(reg);
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