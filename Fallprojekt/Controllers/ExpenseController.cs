using DAL.Model;
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
            ProjectService.Instance.InsertExpense(new Expense
            {
                Amount= expenseDTO.Amount,
                Recipient=expenseDTO.Recipient,
                ExpenseDate=expenseDTO.Date,
                Comment=expenseDTO.Comment
            });
        }
    }
}
