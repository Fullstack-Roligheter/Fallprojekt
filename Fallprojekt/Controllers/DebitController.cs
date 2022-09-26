using Castle.Core.Internal;
using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.DTOs;

namespace Fallprojekt.Controllers
{
    [Route("api/debit")]
    [ApiController]
    public class DebitController : ControllerBase
    {
        [HttpGet("GetDebitListForUser")]
        public IActionResult GetExpensesListForUser([FromQuery]UserIdDTO input)
        {
            try
            {
                var result = DebitService.Instance.GetDebitListForUser(input);
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
                DebitService.Instance.CreateDebit(createDebit);
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
                var result = DebitService.Instance.GetDebitsForBudget(input);
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
                var result = UserService.Instance.CheckUserId(userId);
                if (!result) return NotFound("User not found");
                DebitService.Instance.DeleteDebit(debitId);
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
                var result = UserService.Instance.CheckUserId(input.UserId);
                if (!result) return NotFound("User not found");
                return Ok(DebitService.Instance.GetDebitsForCategory(input));
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
                var result = UserService.Instance.CheckUserId(input.UserId);
                if (!result) return NotFound("User not found");
                DebitService.Instance.EditDebit(input);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500);
            }
        }

        //[HttpPost("/GetExpenseForSpecificBudgetSortedIntoCategories")]
        //public IActionResult GetExpenseForSpecificBudgetSortedIntoCategories(GetExpenseForSpecificBudgetSortedIntoCategoriesInputDTO input)
        //{
        //    try
        //    {
        //        var userIdValidation = UserService.Instance.UserIdValidation(input.UserId);
        //        var budgetIdValidation = BudgetService.Instance.BudgetIdValidation(input.BudgetId);

        //        if (!userIdValidation)
        //        {
        //            return StatusCode(401); // Statuscode 401 = UserId does not exist
        //        }
        //        if (!budgetIdValidation)
        //        {
        //            return StatusCode(402); // Statuscode 402 = BudgetId does not exist
        //        }

        //        var result = ExpenseService.Instance.GetExpensesForSpecificBudgetSortedIntoCategories(input);

        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex);
        //        return StatusCode(418);
        //    }
        //}

        //[HttpGet("expensefilter")]
        //public IActionResult FilterByBudgetCategory([FromQuery] BudgetCategoryExpenseFilterDTO input)
        //{
        //    try
        //    {
        //        return Ok(ExpenseService.Instance.GetExpenseListFilteredByBudgetAndCategory(input));

        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
    }
}