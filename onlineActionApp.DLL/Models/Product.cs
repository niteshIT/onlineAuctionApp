using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace onlineActionApp.DLL.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal StartingPrice { get; set; }
        public int AuctionDuration { get; set; } // Duration in hours
        public DateTime EndTime { get; set; }
        public string Category { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal ReservedPrice { get; set; }
        public int? BoughtBy { get; set; } = null;
        public int SellerId { get; set; }
        public User Seller { get; set; } // Navigation property
        public ICollection<Bid> Bids { get; set; } // Navigation property
    }

}
