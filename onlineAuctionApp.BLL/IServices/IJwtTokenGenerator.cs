using onlineActionApp.DLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onlineAuctionApp.BLL.IServices
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}
