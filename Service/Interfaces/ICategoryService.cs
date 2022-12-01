using Service.DTOs;

namespace Service.Interfaces;

public interface ICategoryService
{
    void CreateCategory(CreateCategoryDTO input);
    void DeleteCategory(DeleteCategoryDTO input);
    void EditCategory(EditCategoryDTO editCategory);
    IList<CategoryDTO> GetCategoriesForUser(GetCategoriesDTO input);
    IList<CategoryDTO> GetUserCreatedCategories(GetCategoriesDTO input);
    IList<CategoryDTO> ListAllCategories();
}