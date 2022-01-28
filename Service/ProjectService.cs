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

        //-- CREATE EXPENSE ---------------------------

        public void InsertExpense(Expense expens)
        {
            using (var context = new ProjectContext())
            {
                context.Add(expens);
                context.SaveChanges();
            }
               
            //{
            //    //var result = context.Expense
            //    //    .Select(x => new ExpenseDTO
            //    //    {

            //    //        Amount = x.Amount,
            //    //        //Category = x.Category,
            //    //        RecipientName = x.Recipient.RecipientName,
            //    //        Date = x.ExpenseDate,
            //    //        Comment = x.Comment
            //    //    })
               
            //}
        }
    }
}