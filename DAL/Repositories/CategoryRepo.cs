using DAL.Models;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class CategoryRepo : ICategoryRepo
{
    private readonly ProjectContext _projectContext;

    public CategoryRepo(ProjectContext projectContext)
    {
        _projectContext = projectContext;
    }

    public IList<Category>? GetAll()
    {
        return _projectContext.Categories
            .Include(c => c.User)
            .ToList();
    }

    public IList<Category>? GetAllForUser(Guid userId)
    {
        return _projectContext.Categories
            .Where(c => c.UserId == userId || c.IsDefault == true)
            .Include(c => c.User)
            .ToList();
    }

    public IList<Category>? GetUserCategories(Guid userId)
    {
        return _projectContext.Categories
            .Where(c => c.UserId == userId)
            .Include(c => c.User)
            .ToList();
    }

    public IList<Category>? GetDefaultCategories()
    {
        return _projectContext.Categories
            .Where(c => c.IsDefault == true)
            .ToList();
    }

    public Category? Get(Guid? modelId)
    {
        return _projectContext.Categories
            .Include(c => c.User)
            .FirstOrDefault(c => c.Id == modelId);
    }

    public void Delete(Guid modelId)
    {
        var model = _projectContext.Categories.FirstOrDefault(c => c.Id == modelId);
        if (model == null) return;
        
        _projectContext.Categories.Remove(model);
        _projectContext.SaveChanges();
    }

    public void DeleteWithModel(Category model)
    {
        _projectContext.Categories.Remove(model);
        _projectContext.SaveChanges();
    }

    public void Update(Category model)
    {
        _projectContext.Categories.Update(model);
        _projectContext.SaveChanges();
    }

    public void Create(Category model)
    {
        _projectContext.Categories.Add(model);
        _projectContext.SaveChanges();
    }

    public void DeleteMultiple(IList<Category> categories)
    {
        _projectContext.Categories.RemoveRange(categories);
        _projectContext.SaveChanges();
    }
}