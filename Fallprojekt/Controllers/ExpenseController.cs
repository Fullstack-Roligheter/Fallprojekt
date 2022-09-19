//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Service;
//using Service.DTOs;

//namespace Fallprojekt.Controllers
//{
//    [Route("api/expense")]
//    [ApiController]
//    public class ExpenseController : ControllerBase
//    {
//        [HttpPost("/AddExpense")]
//        public IActionResult PostExpense(AddExpenseDTO expenseDTO)
//        {
//            try
//            {
//                ExpenseService.Instance.InsertExpense(expenseDTO);
//                return Ok();
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ex);
//            }
//        }
//        [HttpPost("/GetExpenseForSpecificBudget")]
//        public IActionResult GetExpenseForSpecificBudget(GetExpenseForSpecificBudgetInputDTO input)
//        {
//            try
//            {
//                return Ok(ExpenseService.Instance.GetExpensesForSpecificBudget(input));
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine(ex);
//                return StatusCode(500);
//            }
//        }

//        [HttpPost("/GetExpenseForSpecificBudgetSortedIntoCategories")]
//        public IActionResult GetExpenseForSpecificBudgetSortedIntoCategories(GetExpenseForSpecificBudgetSortedIntoCategoriesInputDTO input)
//        {
//            try
//            {
//                var userIdValidation = UserService.Instance.UserIdValidation(input.UserId);
//                var budgetIdValidation = BudgetService.Instance.BudgetIdValidation(input.BudgetId);

//                if (!userIdValidation)
//                {
//                    return StatusCode(401); // Statuscode 401 = UserId does not exist
//                }
//                if (!budgetIdValidation)
//                {
//                    return StatusCode(402); // Statuscode 402 = BudgetId does not exist
//                }

//                var result = ExpenseService.Instance.GetExpensesForSpecificBudgetSortedIntoCategories(input);

//                return Ok(result);
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine(ex);
//                return StatusCode(418);
//            }
//        }

//        [HttpGet("expensefilter")]
//        public IActionResult FilterByBudgetCategory([FromQuery] BudgetCategoryExpenseFilterDTO input)
//        {
//            try
//            {
//                return Ok(ExpenseService.Instance.GetExpenseListFilteredByBudgetAndCategory(input));

//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ex.Message);
//            }
//        }
//    }
//}