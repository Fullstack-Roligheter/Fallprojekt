using DAL;
using Microsoft.EntityFrameworkCore;
using Service.DTOs;
using System.Data.SqlClient;
namespace Service
{
    public class BudgetService
    {
        //SINGLETON--------------------------------------------------------------------------------------------------
        private static BudgetService _instance;
        public static BudgetService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new BudgetService();
                }
                return _instance;
            }
        }
        private BudgetService() { }
        //SINGLETON--------------------------------------------------------------------------------------------------


        public decimal CalculateBudgetFromCatagories(CountMaxMoneyDTO input)
        {
            using (var context = new ProjectContext())
            {
                List<SimpleDecimalDTO> categoryMaxAmountList = new List<SimpleDecimalDTO>();

                categoryMaxAmountList = (from u in context.User
                                         join b in context.Budgets on u.UserId equals b.UserId
                                         join c in context.Categories on b.BudgetId equals c.BudgetId
                                         where u.UserId == input.UserId && input.StartDate >= b.StartDate && input.EndDate <= b.EndDate
                                         select new SimpleDecimalDTO
                                         {
                                             Amount = c.CategoryMaxAmount
                                         }).ToList();

                decimal newBudget = 0;
                foreach (var amount in categoryMaxAmountList)
                {
                    decimal newAmount = amount.Amount;
                    newBudget += newAmount;
                }

                var updateMaxAmount = context.Budgets.First(b => b.UserId == input.UserId);
                updateMaxAmount.MaxAmountMoney = newBudget;
                context.SaveChanges();

                return newBudget; //Man kan använda den här för att returnera värdet till Swagger / Postman
            }
        }
      
        public void AddDefaultBudgetToNewUser(string inputEmail)
        {
            using (var context = new ProjectContext())
            {
                var tempNewUserId = (from u in context.User
                                     where u.Email == inputEmail
                                     select u.UserId).FirstOrDefault();

                var newUserId = Convert.ToInt32(tempNewUserId);

                var newUserDefaultBudget = context.Set<Budget>();
                newUserDefaultBudget.Add(new Budget
                {
                    UserId = newUserId,
                    Name = "Default",
                    StartDate = DateTime.Today,
                    EndDate = DateTime.Today,

                });
                context.SaveChanges();

                CategoryService.Instance.AddDefaultCategoryToNewUser(newUserId);
            }
        }

        public List<string> ListUserBudgets(int inputUserId)
        {
            var budgetList = new List<string>();

            using (var context = new ProjectContext())
            {
                var tempBudgetList = (from u in context.User
                              join b in context.Budgets on u.UserId equals b.UserId
                              where u.UserId == inputUserId
                              select new
                              {
                                  b.Name
                              }).ToList();
                
                foreach (var item in tempBudgetList)
                {
                    budgetList.Add(item.Name);
                }
            }
            return budgetList;
        }
    }
}