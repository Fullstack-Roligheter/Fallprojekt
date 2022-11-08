using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interfaces
{
    public interface IUserRepo
    {
        List<User> GetAllUsers();
        User? GetUser(Guid id);
        User? GetUser(string email);
        void CreateUser(User user);
    }
}
