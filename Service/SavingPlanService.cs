﻿//using DAL;
//using DAL.Models;
//using Service.DTOs;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Service
//{
//    public class SavingPlanService
//    {
//        private static SavingPlanService _instance;
//        public static SavingPlanService Instance
//        {
//            get
//            {
//                if (_instance == null)
//                {
//                    _instance = new SavingPlanService();
//                }
//                return _instance;
//            }
//        }
//        public void CreateSavingPlan(SavingPlanDTO saving)
//        {
//            using (var context = new ProjectContext())
//            {
//                var data = context.User.Where(x => x.UserId == saving.UserId)
//                    .FirstOrDefault();
//                if (data == null)
//                {
//                    throw new Exception("user not found!");
//                }
//                context.Add(
//                    new SavingPlan
//                    {
//                        UserId = saving.UserId,
//                        Name = saving.Name,
//                        Amount = saving.Amount,
//                        PlanStartDate = saving.PlanStartDate,
//                        PlanEndDate = saving.PlanEndDate
//                    });
//                context.SaveChanges();
//            }
//        }
//        public List<GetSavingPlanDTO> ListAllPlan(UserIdDTO user)
//        {
//            using (var context = new ProjectContext())
//            {
//                var data = context.User.Any(x => x.UserId == user.UserId);
//                if (!data)
//                {
//                    throw new Exception("User not found!");
//                }

//                return context.Savingplan.Where(x => x.UserId == user.UserId)
//                    .Select(s => new GetSavingPlanDTO
//                    {
//                        SavingId = s.SavingId,
//                        Name = s.Name,
//                        Amount = s.Amount,
//                        PlanStartDate = s.PlanStartDate.ToString("yyyy-MM-dd"),
//                        PlanEndDate = s.PlanEndDate.ToString("yyyy-MM-dd"),
//                        CountDown = DateDiff(s.PlanStartDate.ToString("yyyy-MM-dd"), s.PlanEndDate.ToString("yyyy-MM-dd"))
//                    })
//                    .ToList();
//            }
//        }
//        public void UpdatePlan(EditSavingPlanDTO editPlan)
//        {
//            using (var context = new ProjectContext())
//            {
//                var plan = context.Savingplan.FirstOrDefault(x => x.SavingId == editPlan.SavingId);
//                if(plan == null)
//                {
//                    throw new NullReferenceException($"No Plan!");
//                }
//                plan.Name = editPlan.Name;
//                plan.Amount = editPlan.Amount;
//                plan.PlanStartDate = editPlan.PlanStartDate;
//                plan.PlanEndDate = editPlan.PlanEndDate;
//                context.SaveChanges();
//            }
//        }
//        public void DeletePlan(int id)
//        {
//            using (var context = new ProjectContext())
//            {
//                var plan = context.Savingplan.FirstOrDefault(x => x.SavingId == id);
//                if (plan == null)
//                {
//                    throw new NullReferenceException($"No Plan!");
//                }                  
//                context.Remove(plan);
//                context.SaveChanges();
//            }
//        }
//        public static int DateDiff(string dateStart, string dateEnd)
//        {
//            DateTime start = Convert.ToDateTime(dateStart);
//            DateTime end = Convert.ToDateTime(dateEnd);
//            TimeSpan ts = end.Subtract(start);
//            return ts.Days + 1;
//        }

//    }
//}
