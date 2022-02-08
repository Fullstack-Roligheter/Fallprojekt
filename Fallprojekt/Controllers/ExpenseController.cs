using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.DTOs;

namespace Fallprojekt.Controllers
{
    [Route("api/expense")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        [HttpPost("/AddExpense")]
        public void PostExpense(ExpenseDTO expenseDTO)
        {
            ExpenseService.Instance.InsertExpense(expenseDTO);
        }
    }
}