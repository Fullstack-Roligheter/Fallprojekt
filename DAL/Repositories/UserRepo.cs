using DAL.Repositories.Interfaces;

namespace DAL.Repositories;

public class UserRepo : IUserRepo
{
    private readonly ProjectContext _projectContext;

    public UserRepo(ProjectContext projectContext)
    {
        _projectContext = projectContext;
    }

    public IList<User> GetAll()
    {
        return _projectContext.Users.ToList();
    }

    public User? GetWithId(Guid modelId)
    {
        return _projectContext.Users.FirstOrDefault(u => u.Id == modelId);
    }

    public void Create(User model)
    {
        _projectContext.Users.Add(model);
        _projectContext.SaveChanges();
    }

    public void Delete(Guid modelId)
    {
        var model = _projectContext.Users.FirstOrDefault(d => d.Id == modelId);
        if (model == null) return;

        _projectContext.Users.Remove(model);
        _projectContext.SaveChanges();
    }

    public void Update(User model)
    {
        var affectedUser = _projectContext.Users.FirstOrDefault(d => d.Id == model.Id);
        if (affectedUser == null) return;

        _projectContext.Users.Update(model);
        _projectContext.SaveChanges();
    }

    public User? GetWithEmail(string email)
    {
        return _projectContext.Users.FirstOrDefault(u => u.Email == email);
    }
}