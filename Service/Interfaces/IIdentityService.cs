using DAL.Models;

namespace Service.Interfaces
{
    public interface IIdentityService
    {
        Task<ResponseModel<JWTTokenModel>> LoginAsync(LoginModel login);
    }
}
