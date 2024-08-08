using AutoMapper;
using onlineActionApp.DLL.Models;
using OnlineAuctionApp.Dtos.Dtos;

namespace onlineAuctionApp.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // User Mappings
            CreateMap<User, UserDto>();
            CreateMap<UserLoginDto, User>();

            // Product Mappings
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.SellerEmail, opt => opt.MapFrom(src => src.Seller.Email));
            CreateMap<ProductCreateDto, Product>();
            CreateMap<ProductUpdateDto, Product>();

            // Bid Mappings
            CreateMap<Bid, BidDto>()
                .ForMember(dest => dest.BidderEmail, opt => opt.MapFrom(src => src.Bidder.Email));
            CreateMap<BidCreateDto, Bid>();
        }
    }
}
