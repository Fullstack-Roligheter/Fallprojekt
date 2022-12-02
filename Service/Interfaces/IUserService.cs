using Service.DTOs;

namespace Service.Interfaces;

public interface IUserService
{
    IList<UserDTO> GetAllUsers();
    SuccessLoginDTO? LogIn(LoginDTO login);
    void UserRegister(RegisterDTO reg);
    void UpdateUserInfo(UserDTO user);
    bool CheckUserId(Guid userId);
    bool CheckEmail(RegisterDTO reg);
}