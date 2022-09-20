using Castle.Core.Internal;
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
        public IActionResult GetExpensesListForUser(Guid userId)
        {
            try
            {
                var result = DebitService.Instance.GetDebitListForUser(userId);
                return result.IsNullOrEmpty() ? StatusCode(404, "UserId not found") : Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpPost("AddDebit")]
        public IActionResult AddDebit(AddDebitDTO expenseDTO)
        {
            try
            {
                DebitService.Instance.AddDebit(expenseDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpPost("GetDebitsForBudget")]
        public IActionResult GetExpenseForSpecificBudget(GetDebitsForBudgetDTO input)
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