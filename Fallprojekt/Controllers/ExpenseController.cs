using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.DTOs;

namespace Fallprojekt.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        [HttpPost("addExpense")]
        public void PostExpense(ExpenseDTO expenseDTO)
        {
            ExpenseService.Instance.InsertExpense(expenseDTO);
        }
    }
}
