using Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IUserService
    {
        List<UserDTO> GetAllUsers();

        SuccessLoginDTO? LogIn(LoginDTO login);

        bool CheckEmail(RegisterDTO reg);

        void UserRegister(RegisterDTO reg);

        bool CheckUserId(Guid userId);

    }
}
