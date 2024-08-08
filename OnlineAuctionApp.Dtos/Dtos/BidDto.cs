using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAuctionApp.Dtos.Dtos
{
    public class BidDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public decimal BidAmount { get; set; }
        public DateTime BidTime { get; set; }
        public int BidderId { get; set; }
        public string BidderEmail { get; set; } // Bidder's email for display purposes
    }

}
