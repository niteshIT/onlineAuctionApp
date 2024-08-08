using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAuctionApp.Dtos.Dtos
{
    public class ProductUpdateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal StartingPrice { get; set; }
        public int AuctionDuration { get; set; } // Duration in hours
        public string Category { get; set; }
        public int? BoughtBy { get; set; }
        public decimal ReservedPrice { get; set; }
    }

}
