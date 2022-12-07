using DAL.Models;

namespace DAL.Repositories.Interfaces;

public interface ISavingPlanRepo
{
    IList<SavingPlan>? GetAll();
    IList<SavingPlan>? GetAllForUser(Guid userId);
    SavingPlan? Get(Guid id);
    void Create(SavingPlan savingPlan);
    void Delete(Guid id);
    void Update(SavingPlan savingPlan);
    void DeleteMultiple(IList<SavingPlan> savingPlans);
}