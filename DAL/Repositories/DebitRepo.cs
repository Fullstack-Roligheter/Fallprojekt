using DAL.Models;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class DebitRepo : IDebitRepo
{
    private readonly ProjectContext _projectContext;

    public DebitRepo(ProjectContext projectContext)
    {
        _projectContext = projectContext;
    }

    public IList<Debit>? GetAll()
    {
        return _projectContext.Debits
            .Include(d => d.Category)
            .Include(d => d.Budget)
            .Include(d => d.User)
            .ToList();
    }

    public IList<Debit>? GetAllWithUserId(Guid userId)
    {
        return _projectContext.Debits
            .Where(d => d.UserId == userId)
            .Include(d => d.Category)
            .Include(d => d.Budget)
            .Include(d => d.User)
            .ToList();
    }

    public IList<Debit>? GetAllWithCategoryId(Guid catId)
    {
        return _projectContext.Debits
            .Where(d => d.CategoryId == catId)
            .Include(d => d.Category)
            .Include(d => d.Budget)
            .Include(d => d.User)
            .ToList();
    }

    public IList<Debit>? GetAllWithBudgetId(Guid budId)
    {
        return _projectContext.Debits
            .Where(d => d.BudgetId == budId)
            .Include(d => d.Category)
            .Include(d => d.Budget)
            .Include(d => d.User)
            .ToList();
    }

    public Debit? Get(Guid modelId)
    {
        return _projectContext.Debits
            .Include(d => d.Category)
            .Include(d => d.Budget)
            .Include(d => d.User)
            .FirstOrDefault(d => d.Id == modelId);
    }

    public void DeleteWithModel(Debit model)
    {
        _projectContext.Debits.Remove(model);
        _projectContext.SaveChanges();
    }

    public void UpdateWithModel(Debit model)
    {
        _projectContext.Debits.Update(model);
        _projectContext.SaveChanges();
    }

    public void UpdateMultiple(IList<Debit> debits)
    {
        _projectContext.Debits.UpdateRange(debits);
        _projectContext.SaveChanges();
    }
    public void DeleteMultiple(IList<Debit> debits)
    {
        _projectContext.Debits.RemoveRange(debits);
        _projectContext.SaveChanges();
    }

    public void Create(Debit model)
    {
        _projectContext.Debits.Add(model);
        _projectContext.SaveChanges();
    }
}