using onlineActionApp.DLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onlineActionApp.DLL.IRepository
{
    public interface IProductRepository
    {
       
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductBySellerId(int SellerId);

        IEnumerable<Product> GetProductByBuyerId(int userId);
        Product GetProductById(int id);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
    }
}
