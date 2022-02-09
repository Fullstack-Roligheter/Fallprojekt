using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service.DTOs;
using System.Data.SqlClient;
namespace Service
{
    public class UserService
    {
        //SINGLETON--------------------------------------------------------------------------------------------------
        private static UserService _instance;
        public static UserService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UserService();
                }
                return _instance;
            }
        }
        private UserService() { }
        //SINGLETON--------------------------------------------------------------------------------------------------


        public List<UserDTO> ListAllUsers()
        {
            using (var context = new ProjectContext())
            {
                return context.User
                    .Select(u => new UserDTO
                    {
                        UserId = u.UserId,
                        Name = u.UserName,
                        Age = u.UserAge,
                        Email = u.UserEmail,
                        Password = u.UserPassword
                    })
                    .ToList();
            }
        }

        public bool LogIn(string username, string password)
        {
            using (var db = new ProjectContext()) //, StringComparison.OrdinalIgnoreCase
            {
                return db.User.Any(u => u.UserName.Equals(username.ToLower()) && u.UserPassword == password);
            }
        }

        public int FetchingUserId(string username)
        {
            using (var db = new ProjectContext())
            {
                return db.User.Where(u => u.UserName == username).Select(i => i.UserId).FirstOrDefault();
            }
        }

        public void UserRegistering(string userName, int age, string email, string password)
        {
            using (var db = new ProjectContext())
            {
                var userExist = db.User.FirstOrDefault(e => e.UserEmail == email);

                if (userExist != null)
                {
                    Console.WriteLine("The email has been used by other user!");
                }
                else
                {
                    db.Add(new User()
                    {
                        UserName = userName.ToLower(),
                        UserAge = age,
                        UserEmail = email,
                        UserPassword = password
                    });
                }
                db.SaveChanges();

                BudgetService.Instance.AddDefaultBudgetToNewUser(email);
            }
        }
    }
}