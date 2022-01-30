﻿using DAL;
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
        public void AddDefaultBudgetAndCategoryToNewUser(string inputEmail)
        {
            //När metoden körs, tar den emot en EMail och tar fram UserId med hjälp av den,
            //sen använder den upphittade UserId för att skapa upp en tuple i Budget tabellen
            //kopplat till den UserId.
            //Sedan tar den fram BudgetId för den nyss skapade tuple i Budget tabellen för nya
            //användaren, och använder den för att skapa en till tuple i Categories tabellen,
            //som är då kopplat till den nyss skapade Budget tuple. Alla nya tuples har Default
            //värden inlagt.
            //Eftersom mer än en SaveContext behövdes, var jag tvungen att dela upp de i seperata
            //metoder. Har behållit den här som utgångsmetod bara.
            
            AddDefaultBudgetToNewUser(inputEmail);
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

                AddDefaultCategoryToNewUser(newUserId);
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
        public double AddAllExpensesInSelectedBudget()
        {
            //Måste fråga gruppen om allting ska sitta i samma metod, eller om det
            //ska uppdelas i flera metoder. t.ex
            //en metod som räknar alla expenses under en budget
            //en metod som räknar alla expenses under en category under en budget
            //osv
            //ELLER
            //göra allting i en metod och skicka en DTO med allting tillbaka till användaren.



            return 0.0;
        }
    }
}