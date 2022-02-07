//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Service;
//using Service.DTOs;
//using System.Collections.Generic;

//namespace Fallprojekt.Controllers
//{
//    [Route("api/basic")]
//    [ApiController]
//    public class BasicController : ControllerBase
//    {
//        [HttpGet] //Exempel Controller
//        public List<UserDTO> ListAllUsers()
//        {
//            return CategoryService.Instance.ListAllUsers();
//        }

//        [HttpPost("/CalculateBudgetFromCatagories")]
//        public decimal CalculateBudgetFromCatagories([FromBody] CountMaxMoneyDTO input)
//        {
//            return CategoryService.Instance.CalculateBudgetFromCatagories(input);
//        }

//        [HttpPost("/AddDefaultBudgetAndCategoryToNewUser")]
//        public void AddDefaultBudgetAndCategoryToNewUser([FromBody] string input)
//        {
//            CategoryService.Instance.AddDefaultBudgetAndCategoryToNewUser(input);
//        }

//        [HttpPost("/ListUserBudgets")]
//        public List<string> ListUserBudgets(int inputUserId)
//        {
//            return CategoryService.Instance.ListUserBudgets(inputUserId);
//        }
//    }
//}
