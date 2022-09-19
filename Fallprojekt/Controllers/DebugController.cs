using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.DTOs;
using System.Collections.Generic;

namespace Fallprojekt.Controllers
{
    [Route("api/debug")]
    [ApiController]
    public class DebugController : ControllerBase
    {
        [HttpGet("/GetDebitListForUser")] //Exempel Controller
        public List<DebitDTO> GetExpensesListForUser(Guid userId)
        {
            return ExpenseService.Instance.GetDebitListForUser(userId);
        }

        //[HttpPost("/CalculateBudgetFromCatagories")]
        //public decimal CalculateBudgetFromCatagories([FromBody] CountMaxMoneyDTO input)
        //{
        //    return BudgetService.Instance.CalculateBudgetFromCatagories(input);
        //}

        //[HttpPost("/AddDefaultBudgetAndCategoryToNewUser")]
        //public void AddDefaultBudgetAndCategoryToNewUser([FromBody] string input)
        //{
        //    BudgetService.Instance.AddDefaultBudgetToNewUser(input);
        //}

        //[HttpPost("/ListUserBudgets")]
        //public List<BudgetNameDTO> ListUserBudgets(UserIdDTO input)
        //{
        //    return BudgetService.Instance.ListUserBudgets(input);
        //}
    }
}