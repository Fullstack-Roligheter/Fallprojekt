using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.DTOs;
using System.Collections.Generic;

namespace Fallprojekt.Controllers
{
    [Route("api/basic")]
    [ApiController]
    public class BasicController : ControllerBase
    {
        [HttpGet("/ListAllUsers")] //Exempel Controller
        public List<UserDTO> ListAllUsers()
        {
            return UserService.Instance.ListAllUsers();
        }

        [HttpPost("/CalculateBudgetFromCatagories")]
        public decimal CalculateBudgetFromCatagories([FromBody] CountMaxMoneyDTO input)
        {
            return BudgetService.Instance.CalculateBudgetFromCatagories(input);
        }

        [HttpPost("/AddDefaultBudgetAndCategoryToNewUser")]
        public void AddDefaultBudgetAndCategoryToNewUser([FromBody] string input)
        {
            BudgetService.Instance.AddDefaultBudgetToNewUser(input);
        }

        [HttpPost("/ListUserBudgets")]
        public List<string> ListUserBudgets(int inputUserId)
        {
            return BudgetService.Instance.ListUserBudgets(inputUserId);
        }
    }
}