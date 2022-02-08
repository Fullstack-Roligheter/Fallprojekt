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
        public bool UserLogin(string user, string password)
        {
            return UserService.Instance.LogIn(user, password);
        }

        [HttpPost("/register")]

        public void UserRegistering(string userName, int age, string email, string password)
        {
            UserService.Instance.UserRegistering(userName, age, email, password);
        }
    }
}