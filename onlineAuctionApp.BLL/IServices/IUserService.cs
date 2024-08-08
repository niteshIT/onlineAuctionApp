using onlineActionApp.DLL.Models;
using OnlineAuctionApp.Dtos.Dtos;
using OnlineAuctionApp.Dtos.Dtos.onlineAuctionApp.BLL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onlineAuctionApp.BLL.IServices
{
    public interface IUserService
    {
        string Authenticate(UserLoginDto userLoginDto);
        UserDto GetUserById(int id);

        User UpdateUser(int id, UserUpdateDto userUpdateDto);
        IEnumerable<User> GetAllUsers();
    }
}
