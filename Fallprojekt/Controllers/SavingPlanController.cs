using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.DTOs;
using Service.Interfaces;

namespace Fallprojekt.Controllers
{
    [Route("api/saving")]
    [ApiController]
    public class SavingPlanController : ControllerBase
    {
        private readonly ISavingPlanService _savingPlanService;
        public SavingPlanController(ISavingPlanService plan)
        {
            _savingPlanService = plan;
        }

        [HttpPost("CreateSavingPlan")]
        public IActionResult CreateSavingPlan([FromBody]SavingPlanDTO saving)
        {
            try
            {
                _savingPlanService.CreateSavingPlan(saving);
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
                return Ok(_savingPlanService.ListAllPlan(user));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("UpdatePlan")]
        public IActionResult UpdateSavingPlan([FromBody]EditSavingPlanDTO editPlan)
        {
            try
            {
                _savingPlanService.UpdatePlan(editPlan);
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
                _savingPlanService.DeletePlan(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }
}
