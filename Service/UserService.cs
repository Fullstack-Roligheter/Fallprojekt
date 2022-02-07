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


        public List<UserDTO> ListAllUsers() //Listar alla Users i User tabellen
        {
            using (var context = new ProjectContext())
            {
                return context.User
                    .Select(u => new UserDTO
                    {
                        UserId = u.UserId,
                        UserName = u.UserName,
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        Age = u.Age,
                        Email = u.Email,
                        Password = u.Password
                    })
                    .ToList();
            }
        }

        public bool LogIn(LoginDTO loginInfo) //Kontrollerar om en viss UserId och Password stämmer överens med databasen
        {
            try
            {
                using (var db = new ProjectContext()) //, StringComparison.OrdinalIgnoreCase
                {
                    return db.User.Any(u => u.UserName.Equals(loginInfo.UserName.ToLower()) && u.Password == loginInfo.Password);
                }
            }
            catch
            {
                return false;
            }
        }

        public int FetchingUserId(string username)
        {
            using (var db = new ProjectContext())
            {
                return db.User.Where(u => u.UserName == username).Select(i => i.UserId).FirstOrDefault();
            }
        }

        public string CreateNewUser(CreateNewUserDTO newUserInfo)
        {
            try
            {
                using (var db = new ProjectContext())
                {
                    var userExist = db.User.FirstOrDefault(e => e.Email == newUserInfo.Email);

                    if (userExist != null)
                    {
                        return $"Email is currently in use...";
                    }
                    else
                    {
                        db.Add(new User()
                        {
                            UserName = newUserInfo.UserName.ToLower(),
                            FirstName = newUserInfo.FirstName.ToLower(),
                            LastName = newUserInfo.LastName.ToLower(),
                            Email = newUserInfo.Email.ToLower(),
                            Password = newUserInfo.Password,
                            Age = 0,
                        });
                        db.SaveChanges();
                        BudgetService.Instance.AddDefaultBudgetToNewUser(newUserInfo.Email.ToLower()); //Skapar en Default Budget till en ny User
                        return $"Success";
                    }
                }
            }
            catch
            {
                return $"Error in Service...";
            }
        }
    }
}