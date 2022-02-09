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
                    CategoryName = "Default",
                    BudgetId = newUserBudgetId,
                    CategoryMaxAmount = 0
                });
                context.SaveChanges();
            }
        }
    }
}