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

    public IList<UserDTO> GetAllUsers()
    {
        var userList = _userRepo.GetAll();
        if (userList == null) throw new NullReferenceException("No Users Found");

        return userList.Select(user => new UserDTO()
            {
                UserId = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password
            })
            .ToList();
    }

    public SuccessLoginDTO? LogIn(LoginDTO login)
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
            throw new Exception($"Error registering User: {ex.Message}");
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