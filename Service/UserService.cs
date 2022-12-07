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

    public async Task<IList<UserDTO>> GetAllUsers()
    {
        try
        {
            var userList = await _userRepo.GetAll();
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
            _logger.LogWarning("Error Caught in UserService/LogIn: Null return ");
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
        catch (Exception ex)
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
                throw new ArgumentException($"Invalid Arguments passed to UpdateUserInfo");
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
                throw new ArgumentException($"Invalid User Argument");
            }

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
                _logger.LogWarning("\nError caught in UserService/GetUserWithIdAndEmailAndPassword: No User Found");
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