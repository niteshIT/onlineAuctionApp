using AutoMapper;
using onlineActionApp.DLL.IRepository;
using onlineActionApp.DLL.Models;
using onlineAuctionApp.BLL.IServices;
using OnlineAuctionApp.Dtos.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onlineAuctionApp.BLL.Service
{
    public class BidService : IBidService
    {
        private readonly IBidRepository _bidRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public BidService(IBidRepository bidRepository, IProductRepository productRepository, IMapper mapper)
        {
            _bidRepository = bidRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public IEnumerable<BidDto> GetBidsByProductId(int productId)
        {
            var bids = _bidRepository.GetBidsByProductId(productId);
            return _mapper.Map<IEnumerable<BidDto>>(bids);
        }

        public BidDto PlaceBid(BidCreateDto bidCreateDto)
        {
            var product = _productRepository.GetProductById(bidCreateDto.ProductId);
            if (product == null) throw new Exception("Product not found.");

            var highestBid = _bidRepository.GetHighestBidByProductId(bidCreateDto.ProductId);
            if (highestBid != null && bidCreateDto.BidAmount <= highestBid.BidAmount) throw new Exception("Bid amount must be higher than the current highest bid.");

            var bid = _mapper.Map<Bid>(bidCreateDto);
            bid.BidTime = DateTime.UtcNow;
            _bidRepository.AddBid(bid);
            return _mapper.Map<BidDto>(bid);
        }

        public BidDto GetHighestBid(int productId)
        {
            var bid = _bidRepository.GetHighestBidByProductId(productId);
            return _mapper.Map<BidDto>(bid);
        }

        public IEnumerable<BidDto> GetBidsByBidderId(int userId)
        {
            var bids = _bidRepository.GetBidsByBidderId(userId);
            return _mapper.Map<IEnumerable<BidDto>>(bids);
        }
    }
}
