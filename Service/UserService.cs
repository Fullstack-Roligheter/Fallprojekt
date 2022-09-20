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


        public List<UserDTO> GetAllUsers()
        {
            using var context = new ProjectContext();
            return context.Users
                .Select(u => new UserDTO
                {
                    UserId = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    Password = u.Password
                })
                .ToList();
        }

        public SuccessLoginDTO? LogIn(LoginDTO login)
        {
            using var db = new ProjectContext();
            var result = (from u in db.Users
                where u.Email == login.Email && u.Password == login.Password
                select new SuccessLoginDTO
                {
                    UserId = u.Id,
                    Email = u.Email,
                    FirstName = u.FirstName,
                    LastName = u.LastName
                }).FirstOrDefault();
            return result;
        }

        //        public int FetchingUserId(string username)
        //        {
        //            using (var db = new ProjectContext())
        //            {
        //                return db.User.Where(u => u.UserName == username).Select(i => i.UserId).FirstOrDefault();
        //            }
        //        }

        public bool CheckEmail(RegisterDTO reg)
        {
            using var context = new ProjectContext();
            return context.Users.Any(u => u.Email == reg.Email);
        }

        public void UserRegister(RegisterDTO reg)
        {
            using var context = new ProjectContext();
            context.Add(new User()
            {
                Id = Guid.NewGuid(),
                FirstName = reg.FirstName.ToLower(),
                LastName = reg.LastName.ToLower(),
                Email = reg.Email,
                Password = reg.Password
            });
            context.SaveChanges();
        }

        public bool CheckUserId(Guid userId)
        {
            using var context = new ProjectContext();
            return context.Users.Any(x => x.Id == userId);
        }

    }
}