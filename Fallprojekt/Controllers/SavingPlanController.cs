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
        [HttpPost("addplan")]
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
        [HttpGet("getplans")]
        public IActionResult ListAllPlan([FromQuery] UserIdDTO user)
        {
            try
            {
                return Ok(SavingPlanService.Instance.ListAllPlan(user));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
