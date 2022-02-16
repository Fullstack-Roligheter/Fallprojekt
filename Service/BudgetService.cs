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
            //Den tar fram alla MaxAmount från alla Categories som tillhör en *input.UserId* där
            //Budget.StartDate >= *input.StartDate* && Budget.EndDate <= *input.EndDate*
            //Den sparar alla resultat som en Lista. Sen räknar ihop alla resultat.
            //Den sedan lägger i den summerade resultat i Category.CategoryMaxAmount och sparar
            //Denna bör köras efter varje ny Category skapas.

            using (var context = new ProjectContext())
            {
                List<SimpleDecimalDTO> categoryMaxAmountList = new List<SimpleDecimalDTO>();

                categoryMaxAmountList = (from u in context.User
                                         join b in context.Budgets on u.UserId equals b.UserId
                                         join c in context.Categories on b.BudgetId equals c.BudgetId
                                         where u.UserId == input.UserId && input.StartDate >= b.BudgetStartDate && input.EndDate <= b.BudgetEndDate
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
                updateMaxAmount.BudgetMaxAmountMoney = newBudget;
                context.SaveChanges();

                return newBudget; //Man kan använda den här för att returnera värdet till Swagger / Postman
            }
        }

        public void AddDefaultBudgetToNewUser(string inputEmail)
        {
            using (var context = new ProjectContext())
            {
                var tempNewUserId = (from u in context.User
                                     where u.UserEmail == inputEmail
                                     select u.UserId).FirstOrDefault();

                var newUserId = Convert.ToInt32(tempNewUserId);

                var newUserDefaultBudget = context.Set<Budget>();
                newUserDefaultBudget.Add(new Budget
                {
                    UserId = newUserId,
                    BudgetName = "Default",
                    BudgetStartDate = DateTime.Today,
                    BudgetEndDate = DateTime.Today,

                });
                context.SaveChanges();

                CategoryService.Instance.AddDefaultCategoryToNewUser(newUserId);
            }
        }

        public List<BudgetNameDTO> ListUserBudgets(UserIdDTO input)
        {
            using (var context = new ProjectContext())
            {
                var budgetList = (from u in context.User
                                      join b in context.Budgets on u.UserId equals b.UserId
                                      where u.UserId == input.UserId
                                      select new BudgetNameDTO
                                      {
                                         BudgetName = b.BudgetName,
                                         BudgetId = b.BudgetId
                                      }).ToList();

                return budgetList;
            }          
        }
    }
}