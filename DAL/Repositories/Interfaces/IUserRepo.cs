namespace DAL.Repositories.Interfaces;

public interface IUserRepo
{
    Task<List<User>> GetAll();
    Task<User?> GetWithId(Guid modelId);
    Task Create(User user);
    Task DeleteWithModel(User model);
    Task Update(User model);
    Task<User?> GetWithEmailAndPassword(string email, string password);
    Task<User?> GetWithIdAndEmailAndPassword(Guid id, string email, string password);
    Task<User?> GetWithEmail(string email);
    Task<User?> GetWholeUser(Guid id, string email, string password);
}