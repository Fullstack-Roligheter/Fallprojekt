using DAL;
using Microsoft.EntityFrameworkCore;
using Service.DTOs;
using System.Data.SqlClient;
using System.Threading.Tasks.Dataflow;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Query.Internal;
using DAL.Models;

namespace Service
{
    public class DebitService
    {
        //SINGLETON--------------------------------------------------------------------------------------------------
        private static DebitService _instance;
        public static DebitService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DebitService();
                }
                return _instance;
            }
        }
        private DebitService() { }
        //SINGLETON--------------------------------------------------------------------------------------------------
        
        public List<DebitDTO> GetAllDebits()
        {
            using var context = new ProjectContext();
            var result = (from d in context.Debits
                select new DebitDTO()
                {
                    Id = d.Id,
                    Date = d.Date,
                    Amount = d.Amount,
                    Comment = d.Comment,
                    Category = d.Category == null ? string.Empty : d.Category.Name,
                    Budget = d.Budget == null ? string.Empty : d.Budget.Name,
                    UserFirstName = d.User.FirstName,
                }).ToList();
            return result;
        }

        public List<DebitDTO> GetDebitListForUser(Guid userId)
        {
            using var context = new ProjectContext();
            var result = (from d in context.Debits
                where d.UserId == userId
                select new DebitDTO()
                {
                    Id = d.Id,
                    Date = d.Date,
                    Amount = d.Amount,
                    Comment = d.Comment,
                    Category = d.Category == null ? string.Empty : d.Category.Name,
                    Budget = d.Budget == null ? string.Empty : d.Budget.Name,
                    UserFirstName = d.User.FirstName,
                }).ToList();
            return result;
        }
        
        public void AddDebit(AddDebitDTO debit)
        {
            using var context = new ProjectContext();
            context.Add(new Debit
            {
                Id = Guid.NewGuid(),
                UserId = debit.UserId,
                Date = debit.Date,
                Amount = debit.Amount,
                Comment = debit.Comment,
                CategoryId = debit.CategoryId,
                BudgetId = debit.BudgetId,
            });
            context.SaveChanges();
        }

        public GetExpenseForSpecificBudgetOutputDTO GetDebitsForBudget(GetDebitsForBudgetDTO input)
        {
            using var context = new ProjectContext();

            var budget = context.Budgets.FirstOrDefault(b => b.Id == input.BudgetId)?.Name;
            var debits = context.Debits.Where(d => d.UserId == input.UserId && d.BudgetId == input.BudgetId).ToList();

            var tempList = debits.Select(item => new GEFSBODebitDTO()
                {
                    ExpenseId = item.Id,
                    Amount = item.Amount,
                    Date = item.Date,
                    Comment = item.Comment ?? string.Empty,
                    CategoryName = item.Category?.Name ?? string.Empty,
                    CategoryId = item.CategoryId ?? Guid.Empty,
                }).ToList();

            var result = new GetExpenseForSpecificBudgetOutputDTO()
            {
                BudgetName = budget,
                Debits = tempList
            };
            return result;
        }
    }

    //public List<FilterByBudgetAndCategoryDTO> GetExpenseListFilteredByBudgetAndCategory(BudgetCategoryExpenseFilterDTO input)
    //{

    //    using (var context = new ProjectContext())
    //    {
    //        var budgetID = context.Budgets
    //            .Where(n => n.BudgetName == input.BudgetName)
    //            .Select(id => id.BudgetId)
    //            .FirstOrDefault();

    //        var CategoryBudget = context.Categories.Where(x => x.CategoryId == budgetID);

    //        var list = context.Expense
    //            .Where(x => x.Category.CategoryId == x.CategoryId)
    //            .Where(x => x.Category.CategoryName == input.CategoryName)
    //            .ToList();

    //        List<FilterByBudgetAndCategoryDTO> expenseList = new List<FilterByBudgetAndCategoryDTO>();
    //        foreach (var category1 in list)
    //        {

    //            expenseList.Add(new FilterByBudgetAndCategoryDTO
    //            {
    //                ExpenseId = category1.ExpenseId,
    //                ExpenseRecipient = category1.ExpenseRecipient,
    //                ExpenseAmount = category1.ExpenseAmount,
    //                ExpenseComment = category1.ExpenseComment,
    //                ExpenseDate = category1.ExpenseDate.ToString("yyyy-mm-dd")

    //            });
    //        }
    //        return expenseList;
    //    }
    //}
    //public ICollection<GetExpenseForSpecificBudgetSortedIntoCategoriesOutputDTO> GetExpensesForSpecificBudgetSortedIntoCategories(GetExpenseForSpecificBudgetSortedIntoCategoriesInputDTO input)
    //{
    //    using (var context = new ProjectContext())
    //    {
    //        var result = (from b in context.Budgets
    //                      join u in context.User on b.UserId equals u.UserId
    //                      where b.BudgetId == input.BudgetId && u.UserId == input.UserId
    //                      select new GetExpenseForSpecificBudgetSortedIntoCategoriesOutputDTO
    //                      {
    //                          BudgetName = b.BudgetName,
    //                          Categories = (
    //                                        from ca in context.Category
    //                                        join b in context.Budgets on ca.BudgetId equals b.BudgetId
    //                                        join u in context.User on u.UserId equals b.UserId
    //                                        where b.BudgetId == input.BudgetId && u.UserId == input.UserId
    //                                        select new GEFSBOCategoryDTO
    //                                        {
    //                                            CategoryName = ca.CategoryName,
    //                                            Expenses = (from e in context.Expense
    //                                                        join c in context.Category on e.CategoryId equals c.CategoryId
    //                                                        join b in context.Budgets on c.BudgetId equals b.BudgetId
    //                                                        join u in context.User on u.UserId equals b.UserId
    //                                                        where
    //                                                            b.BudgetId == input.BudgetId &&
    //                                                            u.UserId == input.UserId &&
    //                                                            e.CategoryId == ca.CategoryId
    //                                                        select new GEFSBOCExpensesDTO
    //                                                        {
    //                                                            Date = e.ExpenseDate.ToString("yyyy-MM-dd"),
    //                                                            Recipient = e.ExpenseRecipient,
    //                                                            Amount = e.ExpenseAmount,
    //                                                            Comment = e.ExpenseComment
    //                                                        }).ToList()
    //                                        }).ToList()
    //                      }).ToList();
    //        return result;
    //    }

    //}
    //}
}