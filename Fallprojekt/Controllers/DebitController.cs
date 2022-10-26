using Castle.Core.Internal;
using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.DTOs;
using Service.Interfaces;

namespace Fallprojekt.Controllers
{
    [Route("api/debit")]
    [ApiController]
    public class DebitController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IDebitService _debitService;

        public DebitController(IUserService userService, IDebitService debitService)
        {
            _userService = userService;
            _debitService = debitService;
        }

        [HttpGet("GetDebitListForUser")]
        public IActionResult GetExpensesListForUser([FromQuery]UserIdDTO input)
        {
            try
            {
                var result = _debitService.GetDebitListForUser(input);
                return result.IsNullOrEmpty() ? StatusCode(404, "UserId not found") : Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpPost("CreateDebit")]
        public IActionResult CreateDebit(CreateDebitDTO createDebit)
        {
            try
            {
                _debitService.CreateDebit(createDebit);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpGet("GetDebitsForBudget")]
        public IActionResult GetDebitsForBudget([FromQuery]GetDebitsDTO input)
        {
            try
            {
                var result = _debitService.GetDebitsForBudget(input);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500);
            }
        }

        [HttpDelete("DeleteDebit")]
        public IActionResult DeleteDebit(Guid userId, Guid debitId)
        {
            try
            {
                var result = _userService.CheckUserId(userId);
                if (!result) return NotFound("User not found");
                _debitService.DeleteDebit(debitId);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpGet("GetDebitsForCategory")]
        public IActionResult GetDebitsForCategory([FromQuery]GetDebitsDTO input)
        {
            try
            {
                var result = _userService.CheckUserId(input.UserId);
                if (!result) return NotFound("User not found");
                return Ok(_debitService.GetDebitsForCategory(input));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500);
            }
        }

        [HttpPut("EditDebit")]
        public IActionResult EditDebit(EditDebitDTO input)
        {
            try
            {
                var result = _userService.CheckUserId(input.UserId);
                if (!result) return NotFound("User not found");
                _debitService.EditDebit(input);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500);
            }
        }
    }
}