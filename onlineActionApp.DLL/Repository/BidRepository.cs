using onlineActionApp.DLL.Data;
using onlineActionApp.DLL.IRepository;
using onlineActionApp.DLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onlineActionApp.DLL.Repository
{
    public class BidRepository : IBidRepository
    {
        private readonly AuctionContext _context;

        public BidRepository(AuctionContext context)
        {
            _context = context;
        }

        public IEnumerable<Bid> GetBidsByProductId(int productId)
        {
            return _context.Bids
                .Where(b => b.ProductId == productId)
                .OrderByDescending(b => b.BidTime)
                .ToList();
        }

        public Bid GetHighestBidByProductId(int productId)
        {
            return _context.Bids
                .Where(b => b.ProductId == productId)
                .OrderByDescending(b => b.BidAmount)
                .FirstOrDefault();
        }

        public IEnumerable<Bid> GetBidsByBidderId(int userId)
        {
            return _context.Bids
                .Where(b => b.BidderId == userId)
                .OrderByDescending(b => b.BidTime)
                .ToList();
        }

        public void AddBid(Bid bid)
        {
            _context.Bids.Add(bid);
            _context.SaveChanges();
        }
    }
}
