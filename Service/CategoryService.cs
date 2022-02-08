using DAL;
using Microsoft.EntityFrameworkCore;
using Service.DTOs;
using System.Data.SqlClient;
namespace Service
{
    public class CategoryService
    {
        //SINGLETON--------------------------------------------------------------------------------------------------
        private static CategoryService _instance;
        public static CategoryService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CategoryService();
                }
                return _instance;
            }
        }
        private CategoryService() { }
        //SINGLETON--------------------------------------------------------------------------------------------------


        public decimal CalculateBudgetMaxFromCatagories(CountMaxMoneyDTO input)
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

        public void AddDefaultCategoryToNewUser(int inputUserId)
        {
            using (var context = new ProjectContext())
            {
                var tempNewUserBudgetId = (from u in context.User
                                           join b in context.Budgets
                                           on u.UserId equals b.UserId
                                           where u.UserId == inputUserId
                                           select b.BudgetId).FirstOrDefault();

                var newUserBudgetId = Convert.ToInt32(tempNewUserBudgetId);

                var newUserDefaultCategory = context.Set<Category>();
                newUserDefaultCategory.Add(new Category
                {
                    Name = "Default",
                    BudgetId = newUserBudgetId,
                    CategoryMaxAmount = 0
                });
                context.SaveChanges();
            }
        }
    }
}