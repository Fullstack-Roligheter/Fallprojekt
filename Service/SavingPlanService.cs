using DAL;
using DAL.Models;
using Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class SavingPlanService
    {
        private static SavingPlanService _instance;
        public static SavingPlanService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SavingPlanService();
                }
                return _instance;
            }
        }
        public void CreateSavingPlan(SavingPlanDTO saving)
        {
            using (var context = new ProjectContext())
            {
                context.Add(
                    new SavingPlan
                    {
                        Name = saving.Name,
                        Amount = saving.Amount,
                        PlanStartDate = saving.PlanStartDate,
                        PlanEndDate = saving.PlanEndDate
                    });
                context.SaveChanges();
            }
        }
        public List<GetSavingPlanDTO> ListAllPlan()
        {
            using (var context = new ProjectContext())
            {
                return context.Savingplan
                    .Select(s => new GetSavingPlanDTO
                    {
                        Name = s.Name,
                        PlanStartDate = s.PlanStartDate,
                        PlanEndDate = s.PlanEndDate,
                        CountDown = DateDiff(s.PlanStartDate, s.PlanEndDate)
                    })
                    .ToList();
            }
        }
        //method som räknar days
        public int DateDiff(string dateStart, string dateEnd)

        {
            DateTime start = Convert.ToDateTime(dateStart);
            DateTime end = Convert.ToDateTime(dateEnd);
            TimeSpan ts = end.Subtract(start);
            return ts.Days + 1;
        }

    }
}
