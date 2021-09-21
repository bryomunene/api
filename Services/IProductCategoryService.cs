using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_api.Models;

namespace web_api.Services
{
    public interface IProductCategoryService
    {
        public List<ProductCategory> GetProductCategories();

        public ProductCategory AddProductCategory(ProductCategory productCategory);

        public ProductCategory UpdateProductCategory(string id, ProductCategory productCategory);

        public string DeleteProductCategory(string id);
    }
}
