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

        public void InsertExpense(AddExpenseDTO expenseDTO)
        {
            
            using (var context = new ProjectContext())
            {                
                var categoryID = context.Categories
                    .Where(n => n.CategoryName == expenseDTO.CategoryName)
                    .Select(id => id.CategoryId)
                    .FirstOrDefault();
                context.Add(
                    new Expense
                    {
                        ExpenseAmount = expenseDTO.Amount,
                        ExpenseRecipient = expenseDTO.Recipient,
                        ExpenseDate = expenseDTO.Date,
                        ExpenseComment = expenseDTO.Comment,
                        CategoryId = categoryID 
                    });
                context.SaveChanges();
            }
        }

        public ICollection<GetExpenseForSpecificBudgetOutputDTO> GetExpensesForSpecificBudget(GetExpenseForSpecificBudgetInputDTO input)
        {
            using (var context = new ProjectContext())
            {
                var result = from b in context.Budgets
                             join u in context.User on b.UserId equals u.UserId
                             where b.BudgetId == input.BudgetId && u.UserId == input.UserId
                             select new GetExpenseForSpecificBudgetOutputDTO
                             {
                                 BudgetName = b.BudgetName,
                                 Expenses = (from e in context.Expense
                                             join c in context.Category on e.CategoryId equals c.CategoryId
                                             join b in context.Budgets on c.BudgetId equals b.BudgetId
                                             join u in context.User on u.UserId equals b.UserId
                                             where b.BudgetId == input.BudgetId && u.UserId == input.UserId
                                             select new GEFSBOExpenseDTO
                                             {
                                                 CategoryName = c.CategoryName,
                                                 Date = e.ExpenseDate.ToString("yyyy-MM-dd"),
                                                 Recipient = e.ExpenseRecipient,
                                                 Amount = e.ExpenseAmount,
                                                 Comment = e.ExpenseComment
                                             }).ToList()
                             };

                return result.ToList();
            }
        }
    }
}