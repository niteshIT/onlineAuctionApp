using onlineActionApp.DLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onlineActionApp.DLL.IRepository
{
    public interface IBidRepository
    {
        IEnumerable<Bid> GetBidsByProductId(int productId);
        IEnumerable<Bid> GetBidsByBidderId(int userId);
        Bid GetHighestBidByProductId(int productId);
        void AddBid(Bid bid);
    }
}
