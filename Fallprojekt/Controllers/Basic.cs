using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.DTOs;
using System.Collections.Generic;

namespace Fallprojekt.Controllers
{
    [Route("/basic")]
    [ApiController]
    public class BasicController : ControllerBase
    {
        [HttpGet] //Exempel Controller
        public List<UserDTO> ListAllUsers()
        {
            return ProjectService.Instance.ListAllUsers();
        }
    }
}
