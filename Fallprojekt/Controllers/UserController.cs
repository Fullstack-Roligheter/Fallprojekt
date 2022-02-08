using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace Fallprojekt.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("/login")]
        public IActionResult UserLogin(string user, string password)
        {
            try
            {
                UserService.Instance.LogIn(user, password);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("/register")]

        public IActionResult UserRegistering(string userName, int age, string email, string password)
        {
            try
            {
                UserService.Instance.UserRegistering(userName, age, email, password);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}