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

        //        public void AddDefaultCategoryToNewUser(int inputUserId)
        //        {
        //            using (var context = new ProjectContext())
        //            {
        //                var tempNewUserBudgetId = (from u in context.User
        //                                           join b in context.Budgets
        //                                           on u.UserId equals b.UserId
        //                                           where u.UserId == inputUserId
        //                                           select b.BudgetId).FirstOrDefault();

        //                var newUserBudgetId = Convert.ToInt32(tempNewUserBudgetId);

        //                var newUserDefaultCategory = context.Set<Category>();
        //                newUserDefaultCategory.Add(new Category
        //                {
        //                    CategoryName = "Default",
        //                    BudgetId = newUserBudgetId,
        //                    CategoryMaxAmount = 0
        //                });
        //                context.SaveChanges();
        //            }
        //        }

        public List<CheckForCategoryDuplicatesDTO> ListAllCategories()
        {
            using var context = new ProjectContext();
            var result = (from c in context.Categories
                select new CheckForCategoryDuplicatesDTO()
                {
                    Id = c.Id,
                    CategoryName = c.Name,
                    UserId = c.UserId == null ? Guid.Empty : c.User.Id,
                }).ToList();
            return result;
        }

        //        //List Category to match budget
        //        public List<CheckForCategoryDuplicatesDTO> ListAllCategoryMatchBudget(BudgetNameDTO budget)
        //        {
        //            using (var context = new ProjectContext())
        //            {
        //                var budgetID = context.Budgets
        //                    .Where(n => n.BudgetName == budget.BudgetName)
        //                    .Select(id => id.BudgetId)
        //                    .FirstOrDefault();

        //                //var CategoryBudget = context.Categories.Where(x => x.CategoryId == budgetID);

        //                return context.Categories.Where(x => x.BudgetId == budgetID)
        //                    .Select(n => new CheckForCategoryDuplicatesDTO
        //                    {
        //                        CategoryName = n.CategoryName,
        //                    })
        //                    .ToList();
        //            }
        //        }

        public void AddNewCategory(NewCategoryDTO input)
        {
            using var context = new ProjectContext();
            var newCategory = context.Set<Category>();
            newCategory.Add(new Category
            {
                Id = Guid.NewGuid(),
                Name = input.Name,
                UserId = input.UserId
            });
            context.SaveChanges();
        }
    }
}