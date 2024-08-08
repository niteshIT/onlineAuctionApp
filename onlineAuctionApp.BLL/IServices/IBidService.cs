using onlineActionApp.DLL.Models;
using OnlineAuctionApp.Dtos.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onlineAuctionApp.BLL.IServices
{
    public interface IBidService
    {
        IEnumerable<BidDto> GetBidsByProductId(int productId);
        IEnumerable<BidDto> GetBidsByBidderId(int userId);
        BidDto PlaceBid(BidCreateDto bidCreateDto);
        BidDto GetHighestBid(int productId);
    }
}
