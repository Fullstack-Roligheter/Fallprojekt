using DAL;
using Microsoft.EntityFrameworkCore;
using Service.DTOs;
using System.Data.SqlClient;

namespace Service
{
    public class ProjectService
    {
        //SINGLETON--------------------------------------------------------------------------------------------------
        private static ProjectService _instance;
        public static ProjectService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ProjectService();
                }
                return _instance;
            }
        }
        //SINGLETON--------------------------------------------------------------------------------------------------

        private ProjectService() { }


        public List<UserDTO> ListAllUsers()
        {
            using (var context = new ProjectContext())
            {
                return context.User
                    .Select(u => new UserDTO
                    {
                        UserId = u.UserId,
                        Name = u.Name,
                        Age = u.Age,
                        Email = u.Email,
                        Password = u.Password
                    })
                    .ToList();
            }
        }

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
                     where u.UserId == input.UserId && input.StartDate >= b.StartDate && input.EndDate <= b.EndDate
                     select new SimpleDecimalDTO
                     {
                        Amount = c.CategoryMaxAmount
                     }).ToList();

                decimal newBudget = 0;
                foreach(var amount in categoryMaxAmountList)
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
    }
}