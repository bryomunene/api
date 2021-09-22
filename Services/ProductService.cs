using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_api.Models;

namespace web_api.Services
{
    public class ProductService
    {
        public DatabaseContext _databaseContext;

        public ProductService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<IEnumerable<Product>> AllProductCategoryById(int Id)
        {
            //.Include(Y => Y.Category)
            return await _databaseContext.product.Where(p => p.CategoryId == Id).ToListAsync();
            throw new NotImplementedException();
        }

        public Product AddProduct(Product product)
        {
            _databaseContext.product.Add(product);
            _databaseContext.SaveChanges();
            return product;
        }

        public Product GetProduct(int Id)
        {
            return _databaseContext.product.FirstOrDefault(x => x.ProductId == Id);
        }
    }
}
