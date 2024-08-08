using onlineActionApp.DLL.Models;
using OnlineAuctionApp.Dtos.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onlineAuctionApp.BLL.IServices
{
    public interface IProductService
    {
        

        IEnumerable<ProductDto> GetAllProducts();

        IEnumerable<ProductDto> GetProductBySellerId(int SellerId);
        IEnumerable<ProductDto> GetProductByBuyerId(int userId);
        ProductDto GetProductById(int id);
        ProductDto CreateProduct(ProductCreateDto productCreateDto);
        bool UpdateProduct(int id, ProductUpdateDto productUpdateDto);
        bool DeleteProduct(int id);
    }
}
