using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace onlineActionApp.DLL.Models
{
    public class Bid
    {
        public int Id { get; set; }
        public int ProductId { get; set; }

        public Product Product { get; set; } // Navigation property
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal BidAmount { get; set; }
        public DateTime BidTime { get; set; }
        public int BidderId { get; set; }


        public User Bidder { get; set; } // Navigation property
    }

}
