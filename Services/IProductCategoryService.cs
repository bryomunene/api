using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_api.Models;

namespace web_api.Services
{
    public interface IProductCategoryService
    {
        List<ProductCategory> GetProductCategories();

        ProductCategory GetProductCategory(int id);

        ProductCategory AddProductCategory(ProductCategory productCategory);

        void UpdateProductCategory(ProductCategory productCategory);

        void DeleteProductCategory(int id);
    }
}
