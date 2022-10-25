using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service.DTOs;
using Service.Interfaces;
using System.Data.SqlClient;

namespace Service
{
    public class UserService : IUserService
    {
        private static ProjectContext _projectContext;

        public UserService (ProjectContext context)
        {
            _projectContext = context;
        }

        public List<UserDTO> GetAllUsers()
        {
           
            return _projectContext.Users
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
            
            var result = (from u in _projectContext.Users
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
            
            return _projectContext.Users.Any(u => u.Email == reg.Email);
        }

        public void UserRegister(RegisterDTO reg)
        {

            _projectContext.Add(new User()
            {
                Id = Guid.NewGuid(),
                FirstName = reg.FirstName.ToLower(),
                LastName = reg.LastName.ToLower(),
                Email = reg.Email,
                Password = reg.Password
            });
            _projectContext.SaveChanges();
        }

        public bool CheckUserId(Guid userId)
        {
            
            return _projectContext.Users.Any(x => x.Id == userId);
        }

    }
}