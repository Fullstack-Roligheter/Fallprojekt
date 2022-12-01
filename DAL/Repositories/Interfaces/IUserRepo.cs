namespace DAL.Repositories.Interfaces;

public interface IUserRepo
{
    IList<User> GetAll();
    User? GetWithId(Guid modelId);
    void Create(User user);
    void Delete(Guid modelId);
    void Update(User model);


    User? GetWithEmail(string email);
}