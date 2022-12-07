using DAL.Models;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories;

public class SavingPlanRepo : ISavingPlanRepo
{
    private readonly ProjectContext _projectContext;

    public SavingPlanRepo(ProjectContext projectContext)
    {
        _projectContext = projectContext;
    }

    public IList<SavingPlan>? GetAll()
    {
        return _projectContext.SavingPlans.ToList();
    }

    public IList<SavingPlan>? GetAllForUser(Guid userId)
    {
        return _projectContext.SavingPlans.Where(c => c.UserId == userId).ToList();
    }

    public SavingPlan? Get(Guid id)
    {
        return _projectContext.SavingPlans.FirstOrDefault(c => c.Id == id);
    }

    public void Delete(Guid id)
    {
        var newItem = _projectContext.SavingPlans.FirstOrDefault(d => d.Id == id);
        if (newItem == null) return;
        
        _projectContext.SavingPlans.Remove(newItem);
        _projectContext.SaveChanges();
    }

    public void Update(SavingPlan model)
    {
        _projectContext.SavingPlans.Update(model);
        _projectContext.SaveChanges();
    }

    public void DeleteMultiple(IList<SavingPlan> savingPlans)
    {
        _projectContext.SavingPlans.RemoveRange(savingPlans);
        _projectContext.SaveChanges();
    }

    public void Create(SavingPlan model)
    {
        _projectContext.SavingPlans.Add(model);
        _projectContext.SaveChanges();
    }
}