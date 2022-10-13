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

        public List<UserCategoriesDTO> GetCategoriesForUser(GetCategoriesDTO input)
        {
            using var context = new ProjectContext();

            var defaultresult = (from c in context.Categories
                                 select new UserCategoriesDTO()
                                 {
                                     CategoryId = c.Id,
                                     CategoryName = c.Name,
                                 }).ToList();
            var customresult = (from c in context.UserCategories
                                where c.UserId == input.UserId
                                select new UserCategoriesDTO()
                                {
                                    CategoryId = c.Id,
                                    CategoryName = c.Name,
                                    UserId = c.UserId
                                }).ToList();

            defaultresult.AddRange(customresult);
            
            List<UserCategoriesDTO> CombinedList = defaultresult;

            return CombinedList;
        }

        public List<UserCategoriesDTO> GetUserCreatedCategories(GetCategoriesDTO input)
        {
            using var context = new ProjectContext();
            var result = (from c in context.UserCategories
                          where c.UserId == input.UserId
                          select new UserCategoriesDTO()
                          {
                              CategoryId = c.Id,
                              CategoryName = c.Name,
                          }).ToList();
            return result;
        }

        public void CreateCategory(CreateCategoryDTO input)
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

        public void DeleteCategory(DeleteCategoryDTO input)
        {
            using var context = new ProjectContext();
            try
            {
                var result = context.Categories.FirstOrDefault(x => x.Id == input.CategoryId);
                if (result == null)
                {
                    throw new NullReferenceException($"No such Category found!");
                }
                var affectedDebits = context.Debits.Where(x => x.CategoryId == input.CategoryId).ToList();
                foreach (var debit in affectedDebits)
                {
                    debit.CategoryId = null;
                }
                context.Categories.Remove(result);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public void EditCategory(EditCategoryDTO editCategory)
        {
            using var context = new ProjectContext();

            var category = context.Categories.FirstOrDefault(x => x.Id == editCategory.CategoryId);
            if (category == null)
            {
                throw new NullReferenceException($"No such Category found!");
            }
            category.Id = editCategory.CategoryId;
            category.Name = editCategory.CategoryName;
            context.SaveChanges();
        }
    }
}