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
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        

        [HttpGet("all")]
        [Authorize(Roles = "admin, user")]
        public IActionResult GetAllProducts()
        {
            var products = _productService.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("seller/{sellerId}")]
        [Authorize(Roles = "admin, user")]
        public IActionResult GetProductsBySellerId(int sellerId)
        {
            var products = _productService.GetProductBySellerId(sellerId);
            return Ok(products);
        }
        [HttpGet("Buyer/{userId}")]
        [Authorize(Roles = "admin, user")]
        public IActionResult GetProductsByBuyerId(int userId)
        {
            var products = _productService.GetProductByBuyerId(userId);
            return Ok(products);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "admin, user")]
        public IActionResult GetProduct(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        [Authorize(Roles = "admin, user")]
        public IActionResult CreateProduct(ProductCreateDto productCreateDto)
        {
            var product = _productService.CreateProduct(productCreateDto);
            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin, user")]
        public IActionResult UpdateProduct(int id, ProductUpdateDto productUpdateDto)
        {
            var updated = _productService.UpdateProduct(id, productUpdateDto);
            if (!updated)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult DeleteProduct(int id)
        {
            var deleted = _productService.DeleteProduct(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
