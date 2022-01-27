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
    }
}
