using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using onlineAuctionApp.BLL.IServices;
using OnlineAuctionApp.Dtos.Dtos;
using System.Data;

namespace onlineAuctionApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BidController : ControllerBase
    {
        private readonly IBidService _bidService;

        public BidController(IBidService bidService)
        {
            _bidService = bidService;
        }

        [HttpGet("product/{productId}")]
        [Authorize(Roles = "admin, user")]
        public IActionResult GetBidsByProductId(int productId)
        {
            var bids = _bidService.GetBidsByProductId(productId);
            return Ok(bids);
        }

        [HttpPost]
        [Authorize(Roles = "user")]
        public IActionResult PlaceBid(BidCreateDto bidCreateDto)
        {
            try
            {
                var bid = _bidService.PlaceBid(bidCreateDto);
                return CreatedAtAction(nameof(GetBidsByProductId), new { productId = bid.ProductId }, bid);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("highest/{productId}")]
        [Authorize(Roles = "admin, user")]
        public IActionResult GetHighestBid(int productId)
        {
            var bid = _bidService.GetHighestBid(productId);
            if (bid == null)
            {
                return NotFound();
            }
            return Ok(bid);
        }

        [HttpGet("bids/{userId}")]
        [Authorize(Roles = "admin, user")]
        public IActionResult GetBidsByBidderId(int userId)
        {
            var bids = _bidService.GetBidsByBidderId(userId);
            return Ok(bids);
        }
    }
}
