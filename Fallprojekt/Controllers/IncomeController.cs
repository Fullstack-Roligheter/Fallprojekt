//using Microsoft.AspNetCore.Mvc;
//using Service;
//using Service.DTOs;

//namespace Fallprojekt.Controllers
//{
//    [Route("api/income")]
//    [ApiController]
//    public class IncomeController : ControllerBase
//    {
//        [HttpPost("/addincome")]
//        public IActionResult AddIncome(IncomeDTO input)
//        {
//            try
//            {

//                IncomeService.Instance.AddIncome(input);
//                return Ok();

//            }
//            catch (Exception ex)
//            {

//                return BadRequest(ex);
//            }
//        }

//        [HttpGet("/getincome")]
//        public IActionResult GetDefaultIncomeCategoryList()
//        {
//            try
//            {
//                return Ok(IncomeService.Instance.DefaultIncomeCategoriesList());

//            }
//            catch (Exception ex)
//            {

//                return BadRequest(ex);
//            }
//        }
//    }
//}
