using Service.DTOs;

namespace Service.Interfaces;

public interface IUserService
{
    IList<UserDTO> GetAllUsers();

    SuccessLoginDTO? LogIn(LoginDTO login);

    bool CheckEmail(RegisterDTO reg);

    void UserRegister(RegisterDTO reg);

    bool CheckUserId(Guid userId);

}