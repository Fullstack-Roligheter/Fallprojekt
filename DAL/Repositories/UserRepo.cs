using DAL.Repositories.Interfaces;

namespace DAL.Repositories;

public class UserRepo : IUserRepo
{
    private readonly ProjectContext _projectContext;

    public UserRepo(ProjectContext projectContext)
    {
        _projectContext = projectContext;
    }

    public List<User> GetAllUsers()
    {
        return _projectContext.Users.ToList();
    }

    public User? GetUser(Guid id)
    {
        return _projectContext.Users.FirstOrDefault(u => u.Id == id);
    }

    public User? GetUser(string email)
    {
        return _projectContext.Users.FirstOrDefault(u => u.Email == email);
    }

    public void CreateUser(User user)
    {
        _projectContext.Users.Add(user);
        _projectContext.SaveChanges();
    }
}