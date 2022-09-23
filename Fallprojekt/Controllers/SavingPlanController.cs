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
        [HttpPost("AddPlan")]
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
        [HttpGet("GetPlans")]
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
        [HttpPut("UpdatePlan/{id}")]
        public IActionResult UpdateSavingPlan(EditSavingPlanDTO editPlan)
        {
            try
            {
                SavingPlanService.Instance.UpdatePlan(editPlan);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
        [HttpDelete("DeletePlan/{id}")]
        public IActionResult DeleteSavingPlan(Guid id)
        {
            try
            {
                SavingPlanService.Instance.DeletePlan(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }
}
