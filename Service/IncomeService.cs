//using DAL;
//using DAL.Models;
//using Microsoft.EntityFrameworkCore;
//using Service.DTOs;

//namespace Service
//{
//    public class IncomeService
//    {
//        private static IncomeService _instance;
//        public static IncomeService Instance
//        {
//            get
//            {
//                if (_instance == null)
//                {
//                    _instance = new IncomeService();
//                }
//                return _instance;
//            }
//        }

//        private IncomeService() { }


//        public void AddIncome(IncomeDTO input)
//        {
//            using (var context = new ProjectContext())
//            {
//                var userId = context.User.Where(u => u.UserId == input.UserId).FirstOrDefault();
//                if (userId == null)
//                {
//                    throw new Exception("User not found in system");
                
//                }

//               var categoryId = context.DefaultIncomeCategories.Where(n => n.Name == input.IncomeCategory).Select(id=>id.Id).FirstOrDefault();

//                context.Add(
//                    new Income
//                    {
//                        UserId = input.UserId,
//                        IncomeName = input.IncomeName,
//                        IncomeCategoryId = categoryId,
//                        CreateDate = input.Created,
//                        Amount = input.Amount,
//                    })  ;
//                context.SaveChanges();
//            }
//        }

//        //this will be modified to get Default and private Income Categories
//        public IEnumerable<DefaultIncomeCategoryDTO> DefaultIncomeCategoriesList() 
//        {
//            //I forget to SetDB for income and incomeCategory but thats not stop me to add income to database??
//            using (var context = new ProjectContext())
//            {
//               return context.DefaultIncomeCategories
//                    .Select(n => new DefaultIncomeCategoryDTO
//                {
//                    CategoryName = n.Name,
//                })
//                    .ToList();
//            }
//        }

       
//    }
//}
