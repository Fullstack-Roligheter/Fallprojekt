using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service.DTOs;
using System.Data.SqlClient;

namespace Service
{
    public class ValidationService
    {
        //SINGLETON--------------------------------------------------------------------------------------------------
        private static ValidationService _instance;
        public static ValidationService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ValidationService();
                }
                return _instance;
            }
        }
        private ValidationService() { }
        //SINGLETON--------------------------------------------------------------------------------------------------


        public bool ValidateUser(int inputUserId)
        {
            using (var context = new ProjectContext())
            {
                return context.User.Any(x => x.UserId == inputUserId);
            }
        }

        public bool ValidateBudget(int inputUserId, int inputBudgetId)
        {
            using (var context = new ProjectContext())
            {

                var result = (from u in context.User
                              join b in context.Budgets on u.UserId equals b.UserId
                              where b.BudgetId == inputBudgetId && u.UserId == inputUserId
                              select u);
                if (result.Any())
                {
                    return false;
                }
                return true;
            }
        }

        public bool CheckForCategoryDuplicates(CheckForCategoryDuplicatesDTO input)
        {
            using (var context = new ProjectContext())
            {

                    var result = (from u in context.User
                                  join b in context.Budgets on u.UserId equals b.UserId
                                  join c in context.Category on b.BudgetId equals c.BudgetId
                                  where c.CategoryName == input.CategoryName && u.UserId == input.UserId
                                  select u);
                if (result.Any())
                {
                    return false;
                }
                return true;
            }
        }

        public bool CheckEmailExist(RegisterDTO reg)
        {
            using (var context = new ProjectContext())
            {
                return context.User.Any(x => x.UserEmail == reg.Email);
            }
        }
    }
}