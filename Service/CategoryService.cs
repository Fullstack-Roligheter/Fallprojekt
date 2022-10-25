using DAL;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Service.DTOs;
using Service.Interfaces;
using System.Data.SqlClient;
namespace Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ProjectContext _projectContext;

        public CategoryService(ProjectContext projectContext)
        {
            _projectContext = projectContext;
        }

        public List<CheckForCategoryDuplicatesDTO> ListAllCategories()
        {
            var result = (from c in _projectContext.Categories
                          select new CheckForCategoryDuplicatesDTO()
                          {
                              Id = c.Id,
                              CategoryName = c.Name,
                              UserId = c.UserId == null ? Guid.Empty : c.User.Id,
                          }).ToList();
            return result;
        }

        public List<UserCategoriesDTO> GetCategoriesForUser(GetCategoriesDTO input)
        {
            var defaultresult = (from c in _projectContext.Categories
                                 select new UserCategoriesDTO()
                                 {
                                     CategoryId = c.Id,
                                     CategoryName = c.Name,
                                 }).ToList();
            var customresult = (from c in _projectContext.UserCategories
                                where c.UserId == input.UserId
                                select new UserCategoriesDTO()
                                {
                                    CategoryId = c.Id,
                                    CategoryName = c.Name,
                                    UserId = c.UserId
                                }).ToList();

            defaultresult.AddRange(customresult);

            List<UserCategoriesDTO> CombinedList = defaultresult;

            return CombinedList;
        }

        public List<UserCategoriesDTO> GetUserCreatedCategories(GetCategoriesDTO input)
        {
            var result = (from c in _projectContext.UserCategories
                          where c.UserId == input.UserId
                          select new UserCategoriesDTO()
                          {
                              CategoryId = c.Id,
                              CategoryName = c.Name,
                          }).ToList();
            return result;
        }

        public void CreateCategory(CreateCategoryDTO input)
        {
            var newCategory = _projectContext.Set<UserCategories>();
            newCategory.Add(new UserCategories
            {
                Id = Guid.NewGuid(),
                Name = input.Name,
                UserId = input.UserId
            });
            _projectContext.SaveChanges();
        }

        public void DeleteCategory(DeleteCategoryDTO input)
        {
            try
            {
                var result = _projectContext.UserCategories.FirstOrDefault(x => x.Id == input.CategoryId);
                if (result == null)
                {
                    throw new NullReferenceException($"No such Category found!");
                }
                var affectedDebits = _projectContext.Debits.Where(x => x.CategoryId == input.CategoryId).ToList();
                foreach (var debit in affectedDebits)
                {
                    debit.CategoryId = null;
                }
                _projectContext.UserCategories.Remove(result);
                _projectContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public void EditCategory(EditCategoryDTO editCategory)
        {
            var category = _projectContext.UserCategories.FirstOrDefault(x => x.Id == editCategory.CategoryId);
            if (category == null)
            {
                throw new NullReferenceException($"No such Category found!");
            }
            category.Id = editCategory.CategoryId;
            category.Name = editCategory.CategoryName;
            _projectContext.SaveChanges();
        }
    }
}