using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class UserRepo : IUserRepo
{
    private readonly ProjectContext _projectContext;

    public UserRepo(ProjectContext projectContext)
    {
        _projectContext = projectContext;
    }

    public Task<List<User>> GetAll()
    {
        try
        {
            var result = _projectContext.Users.ToList();
            return Task.FromResult(result);
        }
        catch(Exception)
        {
            throw;
        }
    }

    public Task<User?> GetWithId(Guid modelId)
    {
        try
        {
            var result = _projectContext.Users.FirstOrDefault(u => u.Id == modelId);
            return Task.FromResult(result);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public Task Create(User model)
    {
        try
        {
            _projectContext.Users.Add(model);
            _projectContext.SaveChanges();
            return Task.CompletedTask;
        }
        catch(Exception)
        {
            throw;
        }
    }

    public Task DeleteWithModel(User model)
    {
        try
        {
            _projectContext.Users.Remove(model);
            _projectContext.SaveChanges();
            return Task.CompletedTask;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public Task<User?> GetWithEmailAndPassword(string email, string password)
    {
        try
        {
            var user = _projectContext.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            return Task.FromResult(user);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public Task<User?> GetWithIdAndEmailAndPassword(Guid id, string email, string password)
    {
        try
        {
            var result =
                _projectContext.Users.FirstOrDefault(u => u.Id == id && u.Email == email && u.Password == password);
            return Task.FromResult(result);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public Task Update(User model)
    {
        try
        {
            _projectContext.Users.Update(model);
            _projectContext.SaveChanges();
            return Task.CompletedTask;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public Task<User?> GetWithEmail(string email)
    {
        try
        {
            var result = _projectContext.Users.FirstOrDefault(u => u.Email == email);
            return Task.FromResult(result);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public Task<User?> GetWholeUser(Guid id, string email, string password)
    {
        try
        {
            var result =
                _projectContext.Users
                    .Include(b => b.Budgets)
                    .Include(c => c.Categories)
                    .Include(s => s.SavingPlans)
                    .Include(c => c.Categories)
                    .Include(d => d.Debits)
                    .FirstOrDefault(u => u.Id == id && u.Email == email && u.Password == password);
            return Task.FromResult(result);
        }
        catch (Exception)
        {
            throw;
        }
    }
}