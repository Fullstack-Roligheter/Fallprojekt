using DAL;
using Service.DTOs;
using Service.Interfaces;
using DAL.Repositories.Interfaces;

namespace Service;

public class UserService : IUserService
{
    private readonly IUserRepo _userRepo;

    public UserService(IUserRepo userRepo)
    {
        _userRepo = userRepo;
    }

    public List<UserDTO> GetAllUsers()
    {
        var userList = _userRepo.GetAllUsers();
        if (userList == null) throw new NullReferenceException("No Users Found");

        var result = new List<UserDTO>();
        foreach (var user in userList)
        {
            result.Add(new UserDTO()
            {
                UserId = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password
            });
        }
        return result;
    }

    public SuccessLoginDTO? LogIn(LoginDTO login)
    {
        var user = _userRepo.GetUser(login.Email);
        if (user == null) throw new NullReferenceException("No User Found");

        return new SuccessLoginDTO()
        {
            UserId = user.Id,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName
        };
    }

    public bool CheckEmail(RegisterDTO reg)
    {
        var user = _userRepo.GetUser(reg.Email);
        return user != null;
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
            _userRepo.CreateUser(newUser);
        }
        catch (Exception ex)
        {
            throw new Exception($"Error registering User: {ex.Message}");
        }
    }

    public bool CheckUserId(Guid userId)
    {
        var user = _userRepo.GetUser(userId);
        return user != null;
    }
}