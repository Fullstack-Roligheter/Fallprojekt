using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.DTOs;
using System.Collections.Generic;

namespace Fallprojekt.Controllers
{
    [Route("api/budget")]
    [ApiController]
    public class BudgetController : ControllerBase
    {
        [HttpPost("/ListAllBudgetForSpecificUser")]
        public List<BudgetNameDTO> ListAllListUserBudgets(UserIdDTO input)
        {
            return BudgetService.Instance.ListUserBudgets(input);
        }
    }
}