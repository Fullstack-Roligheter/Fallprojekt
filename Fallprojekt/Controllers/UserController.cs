//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Service;
//using Service.DTOs;

//namespace Fallprojekt.Controllers
//{
//    [Route("api/user")]
//    [ApiController]
//    public class UserController : ControllerBase
//    {
//        [HttpPost("login")]
//        public IActionResult UserLogin(LoginDTO loginDTO)
//        {
//            try
//            {

//                var result = UserService.Instance.LogIn(loginDTO);
                
//                if(result == null)
//                {
//                    return StatusCode(401);
//                }
//                else 
//                {
//                    return Ok(result);    
//                }

//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine(ex);
//                return StatusCode(500);     //Om du försöker returnera en bad request tillbaka i en
//                                            //json fil kommer du istället få en 500 kod
//                                            //När den inte kan göra om det till en ordentlig json fil
//            }
//        }

//        [HttpPost("register")]

//        public IActionResult UserRegistering(RegisterDTO reg)
//        {
//            if (UserService.Instance.CheckEmailExist(reg))
//            {
//                return StatusCode(401);
//            }
//            else
//            {
//                UserService.Instance.UserRegistering(reg);
//                return Ok();
//            }

//        }
//    }
//}