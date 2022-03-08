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

        public SuccesLoginDTO? LogIn(LoginDTO loginDTO)
        {
            using (var db = new ProjectContext()) //, StringComparison.OrdinalIgnoreCase
            {
                    var tempUserId = (from u in db.User
                                               where u.UserName == loginDTO.UserName
                                               && u.UserPassword == loginDTO.Password
                                               select new SuccesLoginDTO
                                               {
                                                   UserID = u.UserId
                                               }).FirstOrDefault();
                    return tempUserId;
            }
        }

        public int FetchingUserId(string username)
        {
            using (var db = new ProjectContext())
            {
                return db.User.Where(u => u.UserName == username).Select(i => i.UserId).FirstOrDefault();
            }
        }

        public bool CheckEmailExist(RegisterDTO reg)
        {
            using (var context = new ProjectContext())
            {
                return context.User.Any(x => x.UserEmail == reg.Email);
            }
        }
        public void UserRegistering(RegisterDTO reg)
        {
            using (var db = new ProjectContext())
            {
                var userExist = db.User.FirstOrDefault(e => e.UserEmail == reg.Email);
                db.Add(new User()
                {
                    UserName = reg.Name.ToLower(),
                    UserAge = reg.Age,
                    UserEmail = reg.Email,
                    UserPassword = reg.Password
                });
                db.SaveChanges();

                BudgetService.Instance.AddDefaultBudgetToNewUser(reg.Email);
            }
        }

        public bool UserIdValidation(int userId)
        {
            using (var context = new ProjectContext())
            {
                return context.User.Any(x => x.UserId == userId);
            }
        }

    }
}