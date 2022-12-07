namespace DAL.Repositories.Interfaces;

public interface IBudgetRepo
{
    IList<Budget>? GetAll();
    IList<Budget>? GetAllForUser(Guid userId);
    Budget? Get(Guid modelId);
    void Create(Budget model);
    void Delete(Guid modelId);
    void Update(Budget model);
    void DeleteMultiple(IList<Budget> budgets);

}