using Microsoft.EntityFrameworkCore;
using onlineActionApp.DLL.Data;
using onlineActionApp.DLL.IRepository;
using onlineActionApp.DLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onlineActionApp.DLL.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AuctionContext _context;

        public ProductRepository(AuctionContext context)
        {
            _context = context;
        }

        

        public IEnumerable<Product> GetAllProducts()
        {
            return  _context.Products.ToList();

        }

        public Product GetProductById(int id)
        {
            return _context.Products.Find(id);
        }
        public IEnumerable<Product> GetProductBySellerId(int SellerId)
        {
            return _context.Products.Where(p=>p.SellerId==SellerId).ToList();
        }

        public IEnumerable<Product> GetProductByBuyerId(int userId)
        {
            return _context.Products.Where(p => p.BoughtBy == userId).ToList();
        }
        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
        }
    }
}
