using DAL.Models;
using DAL.Repositories.Interfaces;
using Service.DTOs;
using Service.Interfaces;

namespace Service;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepo _categoryRepo;
    private readonly IDebitRepo _debitRepo;

    public CategoryService(
        ICategoryRepo categoryRepo,
        IDebitRepo debitRepo
        )
    {
        _categoryRepo = categoryRepo;
        _debitRepo = debitRepo;
    }

    public IList<CategoryDTO> ListAllCategories()
    {
        var defaultCategories = _categoryRepo.GetAll();
        var result = new List<CategoryDTO>();

        if (defaultCategories != null)
        {
            var categoryList = defaultCategories
                .Select(category => new CategoryDTO()
                {
                    CategoryId = category.Id,
                    CategoryName = category.Name,
                    UserId = category.UserId == null ? Guid.Empty : category.User.Id,
                }).ToList();
            result.AddRange(categoryList);
        }

        return result;
    }

    public IList<CategoryDTO> GetCategoriesForUser(GetCategoriesDTO input)
    {
        var categories = _categoryRepo.GetAllForUser(input.UserId);

        var result = new List<CategoryDTO>();

        if (categories != null)
        {
            var categoryList = categories
                .Select(category => new CategoryDTO()
                {
                    CategoryId = category.Id,
                    CategoryName = category.Name,
                    UserId = category.UserId == null ? Guid.Empty : category.User.Id,
                }).ToList();
            result.AddRange(categoryList);
        }

        return result;
    }

    public IList<CategoryDTO> GetUserCreatedCategories(GetCategoriesDTO input)
    {
        var userCategories = _categoryRepo.GetUserCategories(input.UserId);

        var result = new List<CategoryDTO>();

        if (userCategories != null)
        {
            result = userCategories
                .Select(category => new CategoryDTO()
                {
                    CategoryId = category.Id,
                    CategoryName = category.Name,
                    UserId = category.UserId
                }).ToList();
        }
        return result;
    }

    public void CreateCategory(CreateCategoryDTO input)
    {
        _categoryRepo.Create(new Category()
        {
            Id = Guid.NewGuid(),
            Name = input.Name,
            UserId = input.UserId,
            IsDefault = false
        });
    }

    public void DeleteCategory(DeleteCategoryDTO input)
    {
        var affectedCategory = _categoryRepo.Get(input.CategoryId);

        if (affectedCategory == null)
        {
            throw new NullReferenceException($"No such Category found!");
        }

        if (affectedCategory.IsDefault)
        {
            throw new AccessViolationException($"Unable to Edit Default Categories");
        }

        var affectedDebits = _debitRepo.GetAllWithCategoryId(input.CategoryId);

        if (affectedDebits != null)
        {
            foreach (var debit in affectedDebits)
            {
                debit.CategoryId = null;
                debit.Category = null;
            }
        }
        _categoryRepo.DeleteWithModel(affectedCategory);
    }

    public void EditCategory(EditCategoryDTO editCategory)
    {
        var affectedCategory = _categoryRepo.Get(editCategory.CategoryId);

        if (affectedCategory == null)
        {
            throw new NullReferenceException($"No such Category found!");
        }

        if (affectedCategory.IsDefault)
        {
            throw new AccessViolationException($"Unable to Edit Default Categories");
        }

        affectedCategory.Name = editCategory.CategoryName;

        _categoryRepo.Update(affectedCategory);
    }
}