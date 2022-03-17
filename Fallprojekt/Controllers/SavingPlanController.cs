using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.DTOs;

namespace Fallprojekt.Controllers
{
    [Route("api/saving")]
    [ApiController]
    public class SavingPlanController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateSavingPlan(SavingPlanDTO saving)
        {
            try
            {
                SavingPlanService.Instance.CreateSavingPlan(saving);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public List<GetSavingPlanDTO>ListAllPlan()
        {
            return SavingPlanService.Instance.ListAllPlan();
        }


        //[HttpPost]
        //public int GetDays(DateTime dateStart, DateTime dateEnd)
        //{
        //    return SavingPlanService.Instance.DateDiff(dateStart, dateEnd);
        //}
    }
}
