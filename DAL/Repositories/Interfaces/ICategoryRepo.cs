using DAL.Models;

namespace DAL.Repositories.Interfaces;

public interface ICategoryRepo
{
    IList<Category>? GetAll();
    IList<Category>? GetAllForUser(Guid userId);
    IList<Category>? GetUserCategories(Guid userId);
    IList<Category>? GetDefaultCategories();

    Category? Get(Guid? modelId);
    void Create(Category model);
    void Delete(Guid modelId);
    void DeleteWithModel(Category model);
    void Update(Category model);
}