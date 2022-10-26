using Service.DTOs;

namespace Service.Interfaces
{
    public interface ICategoryService
    {
        void CreateCategory(CreateCategoryDTO input);
        void DeleteCategory(DeleteCategoryDTO input);
        void EditCategory(EditCategoryDTO editCategory);
        List<UserCategoriesDTO> GetCategoriesForUser(GetCategoriesDTO input);
        List<UserCategoriesDTO> GetUserCreatedCategories(GetCategoriesDTO input);
        List<CheckForCategoryDuplicatesDTO> ListAllCategories();
    }
}