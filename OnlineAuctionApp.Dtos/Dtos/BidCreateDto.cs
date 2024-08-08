using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAuctionApp.Dtos.Dtos
{
    public class BidCreateDto
    {
        public int ProductId { get; set; }
        public decimal BidAmount { get; set; }
        public int BidderId { get; set; } // This should be set to the currently logged-in user's ID
    }

}
