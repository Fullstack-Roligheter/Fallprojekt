using DAL;
using Service.DTOs;
using Service.Interfaces;
using DAL.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using DAL.Migrations;

namespace Service;

public class UserService : IUserService
{
    private readonly IUserRepo _userRepo;
    private readonly IDebitRepo _debitRepo;
    private readonly IBudgetRepo _budgetRepo;
    private readonly ICategoryRepo _categoryRepo;
    private readonly ISavingPlanRepo _savingPlanRepo;
    private readonly ILogger<IUserService> _logger;

    public UserService(IUserRepo userRepo, IDebitRepo debitRepo, IBudgetRepo budgetRepo, ICategoryRepo categoryRepo, ISavingPlanRepo savingPlanRepo, ILogger<IUserService> logger)
    {
        _userRepo = userRepo;
        _debitRepo = debitRepo;
        _budgetRepo = budgetRepo;
        _categoryRepo = categoryRepo;
        _savingPlanRepo = savingPlanRepo;
        _logger = logger;
    }

    public async Task<IList<UserDTO>?> GetAllUsers()
    {
        try
        {
            var userList = await _userRepo.GetAll();

            if (userList.Count == 0)
            {
                return null;
            }

            var result = userList.Select(user => new UserDTO()
                {
                    UserId = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Password = user.Password
                })
                .ToList();

            return result;

        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<SuccessLoginDTO?> LogIn(LoginDTO login)
    {
        try
        {
            if (login.Password == "" || login.Email == "")
            {
                throw new ArgumentException("Invalid Credentials");
            }

            var user = await _userRepo.GetWithEmailAndPassword(login.Email, login.Password);
            if (user != null)
            {
                return new SuccessLoginDTO()
                {
                    UserId = user.Id,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName
                };
            }

            return null;

        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task UserRegister(RegisterDTO reg)
    {
        try
        {
            var newUser = new User()
            {
                Id = Guid.NewGuid(),
                FirstName = reg.FirstName.ToLower(),
                LastName = reg.LastName.ToLower(),
                Email = reg.Email,
                Password = reg.Password
            };

            await _userRepo.Create(newUser);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task UpdateUserInfo(User user, UserDTO userInfo)
    {
        try
        {
            if (userInfo.FirstName == "" || userInfo.LastName == "" || userInfo.Email == "" || userInfo.Password == "")
            {
                throw new ArgumentException($"\nError Caught in UserService/DeleteUser: Null Argument\n");
            }

            user.FirstName = userInfo.FirstName;
            user.LastName = userInfo.LastName;
            user.Email = userInfo.Email;
            user.Password = userInfo.Password;

            await _userRepo.Update(user);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task DeleteUser(User user)
    {
        try
        {
            if (user == null)
            {
                throw new ArgumentException($"\nError Caught in UserService/DeleteUser: Null Argument\n");
            }

            var debitsList = _debitRepo.GetAllWithUserId(user.Id);
            if (debitsList is { Count: > 0 }) _debitRepo.DeleteMultiple(debitsList);

            var categoryList = _categoryRepo.GetUserCategories(user.Id);
            if (categoryList is { Count: > 0 }) _categoryRepo.DeleteMultiple(categoryList);
            
            var budgetList = _budgetRepo.GetAllForUser(user.Id);
            if (budgetList is { Count: > 0 }) _budgetRepo.DeleteMultiple(budgetList);

            var savingPlanList = _savingPlanRepo.GetAllForUser(user.Id);
            if (savingPlanList is { Count: > 0 }) _savingPlanRepo.DeleteMultiple(savingPlanList);

            await _userRepo.DeleteWithModel(user);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<bool> CheckUserId(Guid userId)
    {
        try
        {
            var user = await _userRepo.GetWithId(userId);
            return user != null;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<bool> CheckEmail(RegisterDTO reg)
    {
        try
        {
            var user = await _userRepo.GetWithEmail(reg.Email);
            return user != null;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<User?> GetUserWithIdAndEmailAndPassword(Guid id, string email, string password)
    {
        try
        {
            if (email == "" || password == "")
            {
                _logger.LogWarning("\nWARNING caught in UserService/GetUserWithIdAndEmailAndPassword: Null Arguments\n");
                return null;
            }

            var user = await _userRepo.GetWithIdAndEmailAndPassword(id, email, password);
            return user;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<User?> GetUserWithId(Guid userId)
    {
        try
        {
            var user = await _userRepo.GetWithId(userId);
            return user;
        }
        catch (Exception)
        {
            throw;
        }
    }
}