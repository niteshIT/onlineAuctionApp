using onlineActionApp.DLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onlineActionApp.DLL.IRepository
{
    public interface IUserRepository
    {
        User GetUserByEmailAndPassword(string email, string password);
        User GetUserById(int id);
        void Update(User user);
        IEnumerable<User> GetAll();
    }
}
