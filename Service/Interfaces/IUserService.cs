using DAL;
using Service.DTOs;

namespace Service.Interfaces;

public interface IUserService
{
    Task<IList<UserDTO>> GetAllUsers();
    Task<SuccessLoginDTO?> LogIn(LoginDTO login);
    Task UserRegister(RegisterDTO reg);
    Task UpdateUserInfo(User user, UserDTO userInfo);
    Task DeleteUser(User user);
    Task<bool> CheckUserId(Guid userId);
    Task<bool> CheckEmail(RegisterDTO reg);
    Task<User?> GetUserWithIdAndEmailAndPassword(Guid id, string email, string password);
    Task<User?> GetUserWithId(Guid id);
}