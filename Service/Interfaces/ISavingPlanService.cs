using Service.DTOs;

namespace Service.Interfaces;

public interface ISavingPlanService
{
    void CreateSavingPlan(SavingPlanDTO newPlan);
    IList<GetSavingPlanDTO> GetPlans(Guid userId);
    void UpdatePlan(EditSavingPlanDTO editPlan);
    void DeletePlan(Guid planId);
}