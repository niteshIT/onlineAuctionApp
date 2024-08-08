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
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        

        public IEnumerable<ProductDto> GetProductBySellerId(int sellerId)
        {
            var products = _productRepository.GetProductBySellerId(sellerId);
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }
        public IEnumerable<ProductDto> GetProductByBuyerId(int userId)
        {
            var products = _productRepository.GetProductByBuyerId(userId);
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }
        public IEnumerable<ProductDto> GetAllProducts()
        {
            var products = _productRepository.GetAllProducts();
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }
        public ProductDto GetProductById(int id)
        {
            var product = _productRepository.GetProductById(id);
            return _mapper.Map<ProductDto>(product);
        }

        public ProductDto CreateProduct(ProductCreateDto productCreateDto)
        {
            var product = _mapper.Map<Product>(productCreateDto);
            
            _productRepository.AddProduct(product);
            return _mapper.Map<ProductDto>(product);
        }

        public bool UpdateProduct(int id, ProductUpdateDto productUpdateDto)
        {
            var existingProduct = _productRepository.GetProductById(id);
            if (existingProduct == null) return false;

            _mapper.Map(productUpdateDto, existingProduct);
            _productRepository.UpdateProduct(existingProduct);
            return true;
        }

        public bool DeleteProduct(int id)
        {
            var product = _productRepository.GetProductById(id);
            if (product == null) return false;

            _productRepository.DeleteProduct(product);
            return true;
        }
    }
}
