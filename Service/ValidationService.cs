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

        public bool CheckEmailExist(RegisterDTO reg)
        {
            using (var context = new ProjectContext())
            {
                return context.User.Any(x => x.UserEmail == reg.Email);
            }
        }
    }
}