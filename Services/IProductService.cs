using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_api.Models;

namespace web_api.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> AllProductCategoryById(int Id);
        Task<Product> SingleProduct(int Id);

        Product AddProduct(Product product);

        Product GetProduct(int id);

        void UpdateProduct(Product productCategory);

        void DeleteProduct(int id);
    }
}
