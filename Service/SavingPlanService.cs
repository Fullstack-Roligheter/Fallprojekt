﻿using DAL;
using DAL.Models;
using Service.DTOs;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class SavingPlanService: ISavingPlanService
    {
        private readonly ProjectContext _projectContext;
        public SavingPlanService(ProjectContext context)
        {
            _projectContext = context;
        }


        public void CreateSavingPlan(SavingPlanDTO saving)
        {
            using var context = new ProjectContext();
            var data = context.Users
                .FirstOrDefault(x => x.Id == saving.UserId);
            if (data == null)
            {
                throw new Exception("user not found!");
            }
            context.Add(
                new SavingPlan
                {
                    UserId = saving.UserId,
                    Name = saving.Name,
                    Amount = saving.Amount,
                    StartDate = DateTime.Parse(saving.StartDate),
                    EndDate = DateTime.Parse(saving.EndDate)
                });
            context.SaveChanges();
        }

        public List<GetSavingPlanDTO> ListAllPlan(UserIdDTO user)
        {
            using var context = new ProjectContext();
            var data = context.Users.Any(x => x.Id == user.UserId);
            if (!data)
            {
                throw new Exception("User not found!");
            }

            return context.Savingplans.Where(x => x.UserId == user.UserId)
                .Select(s => new GetSavingPlanDTO
                {
                    SavingId = s.Id,
                    Name = s.Name,
                    Amount = s.Amount,
                    PlanStartDate = s.StartDate.ToString("yyyy-MM-dd"),
                    PlanEndDate = s.EndDate.ToString("yyyy-MM-dd"),
                   
                })
                .ToList();
        }

        public void UpdatePlan(EditSavingPlanDTO editPlan)
        {
            using var context = new ProjectContext();
            var plan = context.Savingplans.FirstOrDefault(x => x.Id == editPlan.SavingId);
            if (plan == null)
            {
                throw new NullReferenceException($"No Plan!");
            }
            plan.Name = editPlan.Name;
            plan.Amount = editPlan.Amount;
            plan.StartDate = DateTime.Parse(editPlan.StartDate);
            plan.EndDate = DateTime.Parse(editPlan.EndDate);
            context.SaveChanges();
        }

        public void DeletePlan(Guid id)
        {
            using var context = new ProjectContext();
            var plan = context.Savingplans.FirstOrDefault(x => x.Id == id);
            if (plan == null)
            {
                throw new NullReferenceException($"No Plan!");
            }
            context.Remove(plan);
            context.SaveChanges();
        }

       
    }
}
