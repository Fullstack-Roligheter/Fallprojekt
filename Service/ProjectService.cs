using DAL;
using DAL.Model;
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

        //use userId when you want to build expense and category based on user id 
        int userId = 0;
        //================
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

                //AddDefaultBudgetAndCategoryToNewUser(string email);
            }
        }
        //-- CREATE EXPENSE ---------------------------

        public void InsertExpense(ExpenseDTO expenseDTO)
        {
            using (var context = new ProjectContext())
            {
                context.Add(
                    new Expense
                    {
                        Amount = expenseDTO.Amount,
                        Recipient = expenseDTO.Recipient,
                        ExpenseDate = expenseDTO.Date,
                        Comment = expenseDTO.Comment
                    });
                context.SaveChanges();
            }
        }
    }
}