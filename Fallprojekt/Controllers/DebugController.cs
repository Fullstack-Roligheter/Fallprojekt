using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.DTOs;
using System.Collections.Generic;
using Castle.Core.Internal;

namespace Fallprojekt.Controllers
{
    [Route("api/debug")]
    [ApiController]
    public class DebugController : ControllerBase
    {
        [HttpGet("GetAllUsers")]
        public List<UserDTO> GetAllUsers()
        {
            return UserService.Instance.GetAllUsers();
        }


        [HttpGet("GetAllDebits")]
        public List<DebitDTO> GetAllDebits()
        {
            return DebitService.Instance.GetAllDebits();
        }


        [HttpGet("GetDebitListForUser")]
        public List<DebitDTO> GetExpensesListForUser(UserIdDTO input)
        {
            return DebitService.Instance.GetDebitListForUser(input);
        }


        [HttpGet("ListAllCategories")]
        public IActionResult ListAllCategories()
        {
            try
            {
                var result = CategoryService.Instance.ListAllCategories();
                if (result.IsNullOrEmpty())
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
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