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
        [HttpPost("login")]
        public IActionResult UserLogin([FromBody]LoginDTO loginInfo)
        {
            var validation = UserService.Instance.LogIn(loginInfo);
            if (validation == true)
            {
                return Ok("User Logged In!");
            }
            return BadRequest("Username / Password Incorrect");
        }

        [HttpPost("register")]
        public IActionResult CreateNewUser(CreateNewUserDTO newUserInfo)
        {
            var validation = UserService.Instance.CreateNewUser(newUserInfo);

            if (validation == "Success")
            {
                return Ok(validation);
            }
            return BadRequest(validation);
        }
    }
}
