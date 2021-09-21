using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_api.Models;
using web_api.Services;

namespace web_api.Services
{
    public class ProductsCategoryService : IProductCategoryService
    {
        private List<ProductCategory> _productCategory;

        public ProductsCategoryService()
        {
            _productCategory = new List<ProductCategory>();
        }

        public List<ProductCategory> GetProductCategories()
        {
            return _productCategory;
        }        ProductCategory IProductCategoryService.AddProductCategory(ProductCategory productCategory)
        {
            _productCategory.Add(productCategory);
            return productCategory;
        }

        string IProductCategoryService.DeleteProductCategory(string id)
        {
            for (var index = _productCategory.Count - 1; index >= 0; index--)
            {
                if (_productCategory[index].CategoryId == Convert.ToInt32(id))
                {
                    _productCategory.RemoveAt(index);
                }
            }

            return id;
        }

        ProductCategory IProductCategoryService.UpdateProductCategory(string id, ProductCategory productCategory)
        {
            for (var index = _productCategory.Count - 1; index >= 0; index--)
            {
                if (_productCategory[index].CategoryId == Convert.ToInt32(id))
                {
                    _productCategory[index] = productCategory;
                }
            }
            return productCategory;
        }
    }
}
