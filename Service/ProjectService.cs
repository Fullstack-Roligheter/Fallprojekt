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
        private ProjectService() { }
        //SINGLETON--------------------------------------------------------------------------------------------------

        int userId = 0; //use userId when you want to build expense and category based on user id 
      
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


        public bool LogIn(string username, string password)
        {
            userId = FetchingUserId(username);
            using (var db = new ProjectContext()) //, StringComparison.OrdinalIgnoreCase
            {
                return db.User.Any(u => u.Name.Equals(username.ToLower()) && u.Password == password);
            }
        }
      
        public int FetchingUserId(string username)
        {
            using (var db = new ProjectContext())
            {
                return db.User.Where(u => u.Name == username).Select(i => i.UserId).FirstOrDefault();
            }
        }
  
        public void UserRegistering(string userName, int age, string email, string password)
        {
            using (var db = new ProjectContext())
            {
                var userExist = db.User.FirstOrDefault(e => e.Email == email);

                if (userExist != null)
                {
                    Console.WriteLine("The email has been used by other user!");
                }
                else
                {
                    db.Add(new User()
                    {
                        Name = userName.ToLower(),
                        Age = age,
                        Email = email,
                        Password = password
                    });
                }
                db.SaveChanges();

                AddDefaultBudgetAndCategoryToNewUser(email);
            }
        }
      
        public void InsertExpense(ExpenseDTO expenseDTO)
        {
            using (var context = new ProjectContext())
            {
                context.Add(
                    new Expense
                    {
                        ExpenseAmount = expenseDTO.Amount,
                        ExpenseRecipient = expenseDTO.Recipient,
                        ExpenseDate = expenseDTO.Date,
                        ExpenseComment = expenseDTO.Comment,
                        CategoryId = expenseDTO.CategoryId
                    });
                context.SaveChanges();
            }
        }
    }
}