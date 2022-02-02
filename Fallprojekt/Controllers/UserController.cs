using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace Fallprojekt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("user")]
        public bool UserLogin(string user, string password)
        {
            return ProjectService.Instance.LogIn(user, password);
        }

        [HttpPost("register")]

        public void UserRegistering(string userName, int age, string email, string password)
        {
            ProjectService.Instance.UserRegistering(userName, age, email, password);
        }
    }
}
