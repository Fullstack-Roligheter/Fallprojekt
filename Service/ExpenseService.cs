using DAL;
using Microsoft.EntityFrameworkCore;
using Service.DTOs;
using System.Data.SqlClient;
namespace Service
{
    public class ExpenseService
    {
        //SINGLETON--------------------------------------------------------------------------------------------------
        private static ExpenseService _instance;
        public static ExpenseService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ExpenseService();
                }
                return _instance;
            }
        }
        private ExpenseService() { }
        //SINGLETON--------------------------------------------------------------------------------------------------


        public void InsertExpense(ExpenseDTO expenseDTO)
        {
            using (var context = new ProjectContext())
            {
                context.Add(
                    new Expense
                    {
                        ExpenseAmount = expenseDTO.Amount,
                        ExpenseRecipient = expenseDTO.Recipient,
                        ExpenseDate = expenseDTO.Date,
                        ExpenseComment = expenseDTO.Comment,
                        CategoryId = expenseDTO.CategoryId
                    });
                context.SaveChanges();
            }
        }
    }
}