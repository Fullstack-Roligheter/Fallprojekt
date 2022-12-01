using DAL.Repositories.Interfaces;

namespace DAL.Repositories;

public class BudgetRepo : IBudgetRepo
{
    private readonly ProjectContext _projectContext;

    public BudgetRepo(ProjectContext projectContext)
    {
        _projectContext = projectContext;
    }

    public IList<Budget>? GetAll()
    {
        return _projectContext.Budgets.ToList();
    }

    public IList<Budget>? GetAll(Guid userId)
    {
        return _projectContext.Budgets.Where(c => c.UserId == userId).ToList();
    }

    public Budget? Get(Guid modelId)
    {
        return _projectContext.Budgets.FirstOrDefault(c => c.Id == modelId);
    }

    public void Delete(Guid modelId)
    {
        var model = _projectContext.Budgets.FirstOrDefault(d => d.Id == modelId);
        if (model == null) return;
        
        _projectContext.Budgets.Remove(model);
        _projectContext.SaveChanges();
    }

    public void Update(Budget model)
    {
        throw new NotImplementedException();
    }

    public void Create(Budget model)
    {
        _projectContext.Budgets.Add(model);
        _projectContext.SaveChanges();
    }
}