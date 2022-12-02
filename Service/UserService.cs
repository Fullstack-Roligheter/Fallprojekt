using DAL;
using Service.DTOs;
using Service.Interfaces;
using DAL.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace Service;

public class UserService : IUserService
{
    private readonly IUserRepo _userRepo;
    private readonly ILogger<IUserService> _logger;

    public UserService(IUserRepo userRepo, ILogger<IUserService> logger)
    {
        _userRepo = userRepo;
        _logger = logger;
    }

    public IList<UserDTO> GetAllUsers()
    {
        try
        {
            var userList = _userRepo.GetAll();
            if (userList == null)
            {
                throw new NullReferenceException("No Users Found");
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

    public SuccessLoginDTO? LogIn(LoginDTO login)
    {
        try
        {
            var user = _userRepo.GetWithEmail(login.Email);
            if (user == null) throw new NullReferenceException("No User Found");

            return new SuccessLoginDTO()
            {
                UserId = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public void UserRegister(RegisterDTO reg)
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
            _userRepo.Create(newUser);
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public void UpdateUserInfo(UserDTO user)
    {
        try
        {
            var newUser = new User()
            {
                Id = Guid.NewGuid(),
                FirstName = user.FirstName.ToLower(),
                LastName = user.LastName.ToLower(),
                Email = user.Email,
                Password = user.Password
            };
            _userRepo.Update(newUser);
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public bool CheckUserId(Guid userId)
    {
        var user = _userRepo.GetWithId(userId);
        return user != null;
    }
    public bool CheckEmail(RegisterDTO reg)
    {
        var user = _userRepo.GetWithEmail(reg.Email);
        return user != null;
    }
}