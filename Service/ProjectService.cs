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

        public bool LogIn(string username, string password)
        {
            using (var db = new ProjectContext()) //, StringComparison.OrdinalIgnoreCase
            {
                return db.User.Any(u => u.Name.Equals(username) && u.Password == password);
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
                        Name = userName,
                        Age = age,
                        Email = email,
                        Password = password
                    });
                }
                db.SaveChanges();

                //AddDefaultBudgetAndCategoryToNewUser(string email);
            }
        }
    }
}