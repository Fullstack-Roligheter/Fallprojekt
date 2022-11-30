using DAL;
using DAL.Models;
using DAL.Repositories.Interfaces;
using Service.DTOs;
using Service.Interfaces;

namespace Service;

public class SavingPlanService : ISavingPlanService
{
    private readonly ISavingPlanRepo _savingPlanRepo;
    private readonly IUserRepo _userRepo;

    public SavingPlanService(ISavingPlanRepo savingPlanRepo, IUserRepo userRepo)
    {
        _savingPlanRepo = savingPlanRepo;
        _userRepo = userRepo;
    }


    public void CreateSavingPlan(SavingPlanDTO newPlan)
    {
        var userId = newPlan.UserId;
        FindUser(userId);

        _savingPlanRepo.Create(new SavingPlan
        {
            UserId = newPlan.UserId,
            Name = newPlan.Name,
            Amount = newPlan.Amount,
            StartDate = DateTime.Parse(newPlan.StartDate),
            EndDate = DateTime.Parse(newPlan.EndDate)
        });
    }

    public IList<GetSavingPlanDTO> GetPlans(Guid userId)
    {
        FindUser(userId);

        var savingPlans = _savingPlanRepo.GetAll(userId);
        if (savingPlans == null)
        {
            throw new NullReferenceException("No Saving Plans Found");
        }

        return savingPlans.Select(plan => new GetSavingPlanDTO()
            {
                SavingId = plan.Id,
                Name = plan.Name,
                Amount = plan.Amount,
                PlanStartDate = plan.StartDate.ToString("yyyy-MM-dd"),
                PlanEndDate = plan.EndDate.ToString("yyyy-MM-dd"),
            })
            .ToList();
    }

    public void UpdatePlan(EditSavingPlanDTO editPlan)
    {
        var affectedPlan = _savingPlanRepo.Get(editPlan.SavingId);
        affectedPlan.Name = editPlan.Name;
        affectedPlan.Amount = editPlan.Amount;
        affectedPlan.StartDate = DateTime.Parse(editPlan.StartDate);
        affectedPlan.EndDate = DateTime.Parse(editPlan.EndDate);

        _savingPlanRepo.Update(affectedPlan);
    }

    public void DeletePlan(Guid planId)
    {
        _savingPlanRepo.Delete(planId);
    }

    private User FindUser(Guid userId)
    {
        var user = _userRepo.GetWithId(userId);
        if (user == null)
        {
            throw new NullReferenceException("No User Found");
        }
        return user;
    }
}