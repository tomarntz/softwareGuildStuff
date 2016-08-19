using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Data
{
    public interface IUserRepository
    {
        List<User> GetAll();
        void Add(User user);
        void Delete(int userId);
        void Edit(User user);
        User GetUserById(int id);
    }
}
